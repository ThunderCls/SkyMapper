// --------------------------------------------------------------------------------------------
// This file is part of the code in dds_material_creator by ThePagi and all credits go to him.
// I just made it a library and added some C bindings to make it easier to use in other projects.
// The original code is licensed under the MIT License. See the LICENSE file for details.
// The original code can be found at
// https://github.com/ThePagi/dds_material_creator
// --------------------------------------------------------------------------------------------

use image::{
    GenericImage, 
    GrayImage, 
    Luma, 
    ImageOutputFormat, 
    GenericImageView, 
    Rgba, 
    io::Reader as ImageReader, 
    DynamicImage};
use image_dds::ddsfile::Dds;
use image_dds::{dds_from_image, image_from_dds, ImageFormat};
use std::fs::File;
use std::path::{Path, PathBuf};
use std::os::raw::c_char;
use std::ffi::CStr;

enum ImageProps {
    Grayscale,
    RGB,
    RGBFullAlpha,
    RGBCutoutAlpha,
    Uncompressed,
}

struct InputImages {
    pub diffuse_alpha: Option<DynamicImage>,
    pub height: Option<DynamicImage>,
    pub env_mask: Option<DynamicImage>,
    pub metallic: Option<DynamicImage>,
    pub glossiness: Option<DynamicImage>,
}

impl Default for InputImages {
    fn default() -> Self {
        InputImages {
            diffuse_alpha: None,
            // normal: None,
            // specular: None,
            // glow: None,
            // skin_tint: None,
            height: None,
            // cubemap: None,
            env_mask: None,
            // inner_diffuse: None,
            // inner_depth: None,
            // subsurface: None,
            // backlight: None,
            metallic: None,
            glossiness: None,
        }
    }
}

const ERROR_MESSAGE_SIZE: usize = 1024; // Adjust as needed

#[repr(C)]
pub struct TerrainParallaxArgs {
    diffuse_path: *const c_char,
    height_path: *const c_char,
    name: *const c_char,    
    output: *const c_char,
    high_quality: bool,
    archaic_format: bool
}

#[repr(C)]
pub struct ComplexMaterialArgs {
    environment_path: *const c_char,
    glossiness_path: *const c_char,
    metallic_path: *const c_char,
    height_path: *const c_char,
    name: *const c_char,
    output: *const c_char,
    high_quality: bool,
    archaic_format: bool
}

#[repr(C)]
pub struct TextureToImageArgs {
    input_path: *const c_char,
    output_dir: *const c_char,
    extract_alpha: bool,
    high_quality: bool,
    archaic_format: bool
}

#[repr(C)]
pub struct ImageToTextureArgs {
    input_path: *const c_char,
    output_dir: *const c_char,
    high_quality: bool,
    archaic_format: bool    
}

#[repr(C)]
pub struct Response {
    error_message: *mut u8
}

impl Default for Response {
    fn default() -> Self {
        Response {
            error_message: std::ptr::null_mut()
        }
    }
}

fn set_response_status(response: Option<&mut Response>, message: Option<&str>) {
    if let Some(response) = response {
        if let Some(message) = message {
            if !response.error_message.is_null() {
                write_message(response.error_message, message);
            }
        }
    }
}

fn write_message(ptr: *mut u8, message: &str) {
    if !ptr.is_null() {
        let bytes = message.as_bytes();
        let len = bytes.len().min(ERROR_MESSAGE_SIZE - 1); // Ensure we don't overflow
        unsafe {
            std::ptr::copy_nonoverlapping(bytes.as_ptr(), ptr, len);
            *ptr.add(len) = 0; // Null-terminate the string
        }
    }
}

fn get_complex_material_args(args: &ComplexMaterialArgs) -> Option<(String, String, String, String, String, PathBuf)> {
    let environment_path = unsafe {
        if args.environment_path.is_null() {
            return None;
        }
        match CStr::from_ptr(args.environment_path).to_str() {
            Ok(s) => s.to_string(),
            Err(_) => return None,
        }
    };
    let glossiness_path = unsafe {
        if args.glossiness_path.is_null() {
            return None;
        }
        match CStr::from_ptr(args.glossiness_path).to_str() {
            Ok(s) => s.to_string(),
            Err(_) => return None,
        }
    };
    let metallic_path = unsafe {
        if args.metallic_path.is_null() {
            return None;
        }
        match CStr::from_ptr(args.metallic_path).to_str() {
            Ok(s) => s.to_string(),
            Err(_) => return None,
        }
    };
    let height_path = unsafe {
        if args.height_path.is_null() {
            return None;
        }
        match CStr::from_ptr(args.height_path).to_str() {
            Ok(s) => s.to_string(),
            Err(_) => return None,
        }
    };
    let name = unsafe {
        if args.name.is_null() {
            return None;
        }
        match CStr::from_ptr(args.name).to_str() {
            Ok(s) => s.to_string(),
            Err(_) => return None,
        }
    };
    let output_str = unsafe {
        if args.output.is_null() {
            return None;
        }
        match CStr::from_ptr(args.output).to_str() {
            Ok(s) => s.to_string(),
            Err(_) => return None,
        }
    };
    let out_dir: PathBuf = PathBuf::from(output_str);
    Some((environment_path, glossiness_path, metallic_path, height_path, name, out_dir))
}

fn get_terrain_parallax_args(args: &TerrainParallaxArgs) -> Option<(String, String, String, PathBuf)> {
    let diffuse_path = unsafe {
        if args.diffuse_path.is_null() {
            return None;
        }
        match CStr::from_ptr(args.diffuse_path).to_str() {
            Ok(s) => s.to_string(),
            Err(_) => return None,
        }
    };
    let height_path = unsafe {
        if args.height_path.is_null() {
            return None;
        }
        match CStr::from_ptr(args.height_path).to_str() {
            Ok(s) => s.to_string(),
            Err(_) => return None,
        }
    };
    let name = unsafe {
        if args.name.is_null() {
            return None;
        }
        match CStr::from_ptr(args.name).to_str() {
            Ok(s) => s.to_string(),
            Err(_) => return None,
        }
    };
    let output_str = unsafe {
        if args.output.is_null() {
            return None;
        }
        match CStr::from_ptr(args.output).to_str() {
            Ok(s) => s.to_string(),
            Err(_) => return None,
        }
    };
    let out_dir: PathBuf = PathBuf::from(output_str);
    Some((diffuse_path, height_path, name, out_dir))
}

fn get_texture_to_image_args(args: &TextureToImageArgs) -> Option<(String, String)> {
    let input_path = unsafe {
        if args.input_path.is_null() {
            return None;
        }
        match CStr::from_ptr(args.input_path).to_str() {
            Ok(s) => s.to_string(),
            Err(_) => return None,
        }
    };
    
    let output_dir = unsafe {
        if args.output_dir.is_null() {
            return None;
        }
        match CStr::from_ptr(args.output_dir).to_str() {
            Ok(s) => s.to_string(),
            Err(_) => return None,
        }
    };
    Some((input_path, output_dir))
}

fn get_image_to_texture_args(args: &ImageToTextureArgs) -> Option<(String, String)> {
    let input_path = unsafe {
        if args.input_path.is_null() {
            return None;
        }
        match CStr::from_ptr(args.input_path).to_str() {
            Ok(s) => s.to_string(),
            Err(_) => return None,
        }
    };
    
    let output_dir = unsafe {
        if args.output_dir.is_null() {
            return None;
        }
        match CStr::from_ptr(args.output_dir).to_str() {
            Ok(s) => s.to_string(),
            Err(_) => return None,
        }
    };
    Some((input_path, output_dir))
}

fn pick_format(properties: ImageProps, use_old_format: bool, high_quality: bool) -> ImageFormat {
    match use_old_format {
        true => match properties {
            ImageProps::Grayscale => ImageFormat::BC1Unorm,
            ImageProps::RGB => ImageFormat::BC1Unorm,
            ImageProps::RGBFullAlpha => ImageFormat::BC3Unorm,
            ImageProps::RGBCutoutAlpha => ImageFormat::BC1Unorm,
            ImageProps::Uncompressed => ImageFormat::R8G8B8A8Unorm,
        },
        false => match properties {
            ImageProps::Grayscale => ImageFormat::BC4Unorm,
            ImageProps::RGB => {
                if high_quality {
                    ImageFormat::BC7Unorm
                } else {
                    ImageFormat::BC1Unorm
                }
            }
            ImageProps::RGBFullAlpha => ImageFormat::BC7Unorm,
            ImageProps::RGBCutoutAlpha => {
                if high_quality {
                    ImageFormat::BC7Unorm
                } else {
                    ImageFormat::BC1Unorm
                }
            }
            ImageProps::Uncompressed => ImageFormat::R8G8B8A8Unorm,
        },
    }
}

fn load_input_image<P>(path: Option<P>) -> Option<DynamicImage>
where
    P: AsRef<Path> + std::fmt::Debug,
{
    if path.is_none() {
        return None;
    }
    let path = path.unwrap();
    match ImageReader::open(path) {
        Ok(reader) => match reader.decode() {
            Ok(img) => {
                Some(img)
            }
            Err(_) => {                
                None
            }
        },
        Err(_) => {         
            None
        }
    }
}

fn determine_image_props(img: &DynamicImage) -> Option<ImageProps> {
    match img.color() {
        image::ColorType::L8 => Some(ImageProps::Grayscale),
        image::ColorType::La8 => Some(ImageProps::Grayscale),
        image::ColorType::Rgb8 => Some(ImageProps::RGB),
        image::ColorType::Rgba8 => Some(
            if img
                .as_rgba8()
                .unwrap()
                .iter()
                .all(|p| *p == u8::MIN || *p == u8::MAX)
            {
                ImageProps::RGBCutoutAlpha
            } else {
                ImageProps::RGBFullAlpha
            },
        ),
        image::ColorType::L16 => Some(ImageProps::Grayscale),
        image::ColorType::La16 => Some(ImageProps::Grayscale),
        image::ColorType::Rgb16 => Some(ImageProps::RGB),
        image::ColorType::Rgba16 => Some(
            if img
                .as_rgba16()
                .unwrap()
                .iter()
                .all(|p| *p == u16::MIN || *p == u16::MAX)
            {
                ImageProps::RGBCutoutAlpha
            } else {
                ImageProps::RGBFullAlpha
            },
        ),
        image::ColorType::Rgb32F => Some(ImageProps::RGB),
        image::ColorType::Rgba32F => Some(ImageProps::RGBFullAlpha),
        _ => {
            println!("Unsupported pixel format {:?}! Skipping...", img.color());
            None
        }
    }
}

fn create_complex_material(images: &InputImages, args: &ComplexMaterialArgs) -> Option<Dds> {
    let (w, h) = {
        if let Some(img) = &images.env_mask{
            (img.width(), img.height())
        }
        else if let Some(img) = &images.glossiness{
            (img.width(), img.height())
        }
        else if let Some(img) = &images.metallic{
            (img.width(), img.height())
        }
        else if let Some(img) = &images.height{
            (img.width(), img.height())
        }
        else{
            return None
        }
    };
    let mut res = image::RgbaImage::new(w, h);
    for y in 0..res.height() {
        for x in 0..res.width() {
            res.put_pixel(x, y, Rgba([0, 5, 0, 0]));
        }
    }
    if let Some(img) = &images.env_mask{
        for y in 0..img.height() {
            for x in 0..img.width() {
                let p = img.get_pixel(x, y);
                res.get_pixel_mut(x, y).0[0] = p.0[0];
            }
        }
    }
    if let Some(img) = &images.glossiness{
        for y in 0..img.height() {
            for x in 0..img.width() {
                let p = img.get_pixel(x, y);
                res.get_pixel_mut(x, y).0[1] = p.0[0];
            }
        }
    }
    if let Some(img) = &images.metallic{
        for y in 0..img.height() {
            for x in 0..img.width() {
                let p = img.get_pixel(x, y);
                res.get_pixel_mut(x, y).0[2] = p.0[0];
            }
        }
    }
    if let Some(img) = &images.height{
        for y in 0..img.height() {
            for x in 0..img.width() {
                let p = img.get_pixel(x, y);
                res.get_pixel_mut(x, y).0[3] = p.0[0];
            }
        }
    }
    Some(
        dds_from_image(
            &res,
            pick_format(ImageProps::RGBFullAlpha, args.archaic_format, args.high_quality),
            image_dds::Quality::Slow,
            image_dds::Mipmaps::GeneratedAutomatic,
        )
        .unwrap(),
    )
}

fn create_terrain_parallax(images: &InputImages, args: &TerrainParallaxArgs) -> Option<Dds> {
    if let Some(img) = &images.diffuse_alpha {
        let mut res = image::RgbaImage::new(img.width(), img.height());
        let mut props = determine_image_props(img)?;
        if let Err(_) = res.copy_from(img, 0, 0) {        
            return None;
        }
        
        if let Some(height) = &images.height {
            props = ImageProps::RGBFullAlpha;
            for y in 0..height.height() {
                for x in 0..height.width() {
                    let p = height.get_pixel(x, y);
                    res.get_pixel_mut(x, y).0[3] = p.0[0]; // set height.r to result.a
                }
            }
        } else {
            return None;
        }
                
        let format = pick_format(props, args.archaic_format, args.high_quality);
        Some(
            dds_from_image(
                &res,
                format,
                image_dds::Quality::Slow,
                image_dds::Mipmaps::GeneratedAutomatic,
            )
            .unwrap(),
        )
    } else {
        None
    }
}

fn create_generic(image: &Option<DynamicImage>, props: ImageProps, args: &ImageToTextureArgs) -> Option<Dds> {
    if let Some(img) = image {
        let mut res = image::RgbaImage::new(img.width(), img.height());
        if let Err(e) = res.copy_from(img, 0, 0) {            
            return None;
        }
        let format = pick_format(props, args.archaic_format, args.high_quality);
        Some(
            dds_from_image(
                &res,
                format,
                image_dds::Quality::Slow,
                image_dds::Mipmaps::GeneratedAutomatic,
            )
            .unwrap(),
        )
    } else {
        None
    }
}


// --------------------------------
// Exported functions
// --------------------------------
#[no_mangle]
pub extern "C" fn create_complex_material_map(args: &ComplexMaterialArgs, response: Option<&mut Response>) -> bool {
    let (environment_path, glossiness_path, metallic_path, height_path, name, out_dir) = 
        match get_complex_material_args(args) {
            Some(value) => value,
            None => {
                set_response_status(response, Some("Invalid arguments provided"));
                return false;
            },
    };
    
    // env_mask, glossiness and metallic maps are hard to automate and be truly accurate
    // to the material. It can be misleading for materials where color and glossiness are not related.
    let mut images = InputImages::default();
    images.env_mask = load_input_image(Some(environment_path));
    images.glossiness = load_input_image(Some(glossiness_path));
    images.metallic = load_input_image(Some(metallic_path));
    images.height = load_input_image(Some(height_path));
    
    let texture = match create_complex_material(&images, &args) {
        Some(tex) => tex,
        None => {
            set_response_status(response, Some("Error decoding input images or input images missing"));
            return false;
        }
    };

    let out_path = out_dir.join(format!("{}_m.dds", name));
    let mut file = match File::create(out_path) {
        Ok(f) => f,
        Err(e) => {
            set_response_status(response, Some(&format!("Failed to create output file: {:?}", e)));
            return false;
        },
    };

    if let Err(e) = texture.write(&mut file) {
        set_response_status(response, Some(&format!("Failed to write DDS file: {:?}", e)));
        return false;
    }    

    return true;
}

#[no_mangle]
pub extern "C" fn create_terrain_parallax_map(args: &TerrainParallaxArgs, response: Option<&mut Response>) -> bool {
    let (diffuse_path, height_path, name, out_dir) = match get_terrain_parallax_args(args) {
        Some(value) => value,
        None => {
            set_response_status(response, Some("Invalid arguments provided"));
            return false;
        },
    };

    let mut images = InputImages::default();
    images.diffuse_alpha = load_input_image(Some(diffuse_path));
    images.height = load_input_image(Some(height_path));

    let texture = match create_terrain_parallax(&images, &args) {
        Some(tex) => tex,
        None => {
            set_response_status(response, Some("Cannot copy diffuse image to rgba8 texture or height map missing"));
            return false;
        }
    };

    let out_path = out_dir.join(format!("{}.dds", name));
    let mut file = match File::create(out_path) {
        Ok(f) => f,
        Err(e) => {
            set_response_status(response, Some(&format!("Failed to create output file: {:?}", e)));
            return false;
        },
    };

    if let Err(e) = texture.write(&mut file) {
        set_response_status(response, Some(&format!("Failed to write DDS file: {:?}", e)));
        return false;
    }    

    return true;    
}

#[no_mangle]
pub extern "C" fn texture_to_image(args: &TextureToImageArgs, response: Option<&mut Response>) -> bool {
    let (input_file, output_dir) = match get_texture_to_image_args(args) {
        Some(value) => value,
        None => {
            set_response_status(response, Some("Invalid arguments provided"));
            return false;
        }
    };
    
    let out_path = PathBuf::from(output_dir);    
    let in_file = PathBuf::from(input_file.clone());

    let tex = match image_dds::ddsfile::Dds::read(File::open(&in_file).unwrap()){
        Ok(t) => t,
        Err(e) => {
            set_response_status(
                response, 
                Some(&format!("Can't read dds at {}: {}", input_file.clone(), e)));  
            return false;
        },          
    };
    let img = match image_from_dds(&tex, 0){
        Ok(img) => img,
        Err(e) => {
            set_response_status(
                response, 
                Some(&format!("Can't convert dds to image: {}", e)));
            return false;
        },
    };

    let name = in_file
        .file_stem()
        .and_then(|stem| stem.to_str().map(String::from));

    let mut images: Vec<(String, DynamicImage)> = vec![];
    let rgb = DynamicImage::ImageRgb8(DynamicImage::ImageRgba8(img.clone()).into_rgb8());
    // Handle the name Option
    if let Some(ref name) = name {
        // Push the RGB image with the original name
        images.push((name.clone(), rgb));

        // Extract alpha channel if any pixel has non-opaque alpha
        if args.extract_alpha && !img.pixels().all(|p| p.0[3] == 255) {
            let mut a = GrayImage::new(img.width(), img.height());
            for y in 0..img.height() {
                for x in 0..img.width() {
                    let p = img.get_pixel(x, y);
                    a.put_pixel(x, y, Luma([p.0[3]]));
                }
            }            
            images.push((format!("{}_alpha", name), DynamicImage::ImageLuma8(a)));
        }
    }
    
    for (name, img) in images {
        let out_path = out_path.join(format!("{}.png", name));
        let mut file = match File::create(out_path){
            Ok(f) => f,
            Err(e) => {
                set_response_status(
                    response, 
                    Some(&format!("Failed to create output file: {:?}", e)));
                return false;
            },
        };
        if let Err(e) = img.write_to(&mut file, ImageOutputFormat::Png) {
            set_response_status(
                response, 
                Some(&format!("Failed to write image file: {:?}", e)));
            return false;
        }
    }

    return true;
}

#[no_mangle]
pub extern "C" fn image_to_texture(args: &ImageToTextureArgs, response: Option<&mut Response>) -> bool {
    let (input_file, output_dir) = match get_image_to_texture_args(args) {
        Some(value) => value,
        None => {
            set_response_status(response, Some("Invalid arguments provided"));
            return false;
        }
    };
    
    let out_path = PathBuf::from(output_dir);    
    let in_file = PathBuf::from(input_file.clone());

    let image = load_input_image(Some(in_file.clone()));
    if image.is_none() {
        set_response_status(
            response, 
            Some(&format!("Cannot load image at {}!", input_file.clone())));
        return false;
    }
    let props = determine_image_props(&image.clone().unwrap());
    if props.is_none() {
        set_response_status(
            response, 
            Some("Cannot determine image properties or image is not supported"));
        return false;
    }
    let texture = match create_generic(&image.clone(), props.unwrap(), args) {
        Some(tex) => tex,
        None => {
            set_response_status(response, Some("Cannot copy image to rgba8 texture"));
            return false;
        }
    };  
    
    let name = in_file
        .file_stem()
        .and_then(|stem| stem.to_str().map(String::from));

    let out_path = out_path.join(format!("{}.dds", name.unwrap()));
    let mut file = match File::create(out_path) {
        Ok(f) => f,
        Err(e) => {
            set_response_status(response, Some(&format!("Failed to create output file: {:?}", e)));
            return false;
        },
    };

    if let Err(e) = texture.write(&mut file) {
        set_response_status(response, Some(&format!("Failed to write DDS file: {:?}", e)));
        return false;
    }    

    return true;   
}

// --------------------------------