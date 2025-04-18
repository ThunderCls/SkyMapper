using ImageMagick;
using Microsoft.Extensions.Logging;

namespace SkyMapper.UI;

public partial class FrmVisualizer : Form
{
    private readonly ILogger<FrmMain> _logger;
    private readonly string _imagePath;
    
    public FrmVisualizer(ILogger<FrmMain> logger, string imagePath)
    {
        InitializeComponent();
        _logger = logger;
        _imagePath = imagePath;
    }

    private void frmVisualizer_Load(object sender, EventArgs e)
    {
        try
        {
            Text = _imagePath;
            using var image = new MagickImage(_imagePath);
            image.Alpha(AlphaOption.Off);
            
            using var memoryStream = new MemoryStream();
            image.Write(memoryStream, MagickFormat.Png);
            memoryStream.Position = 0;
            pictureBox1.Image = new Bitmap(memoryStream);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on image preview");
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }
    }
}