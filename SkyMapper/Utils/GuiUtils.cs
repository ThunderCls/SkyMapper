using System.Runtime.InteropServices;
using SkyMapper.DataAccess.Dtos;

namespace SkyMapper.Utils;

public static class GuiUtils
{
    private const int MF_BYPOSITION = 0x400;
    [DllImport("User32")]
    private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
    [DllImport("User32")]
    private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
    [DllImport("User32")]
    private static extern int GetMenuItemCount(IntPtr hWnd);
    
    public static void UpdateListViewItems(ListView listView, List<string> itemsList)
    {
        listView.Items.Clear();

        foreach (var item in itemsList)
        {
            var listItem = new ListViewItem
            {
                Name = item,
                Text = item
            };

            listView.Items.Add(listItem);
        }
    }
    
    public static void UpdateListViewItems<T>(ListView listView, List<T> itemsList)
    {
        listView.Items.Clear();

        var properties = itemsList.FirstOrDefault()?.GetType().GetProperties();
        if (properties is null) return;

        foreach (var item in itemsList)
        {
            var value = properties.FirstOrDefault()?.GetValue(item);
            var listItem = new ListViewItem
            {
                Name = value?.ToString(),
                Text = value?.ToString()
            };

            if (properties.Length > 1)
            {
                foreach (var property in properties.Skip(1))
                {
                    value = property.GetValue(item);
                    listItem.SubItems.Add(value?.ToString());
                }
            }

            listView.Items.Add(listItem);
        }
    }
    
    public static void UpdateWorkerStatus(ListView listView, TextureFileListItem fileItem, Color? rowColor = null)
    {
        var listEntry = listView.Items.Find(fileItem.FilePath, false).FirstOrDefault();
        if (listEntry is not null)
        {
            if (rowColor is not null)
                listEntry.ForeColor = rowColor.Value;

            if (listEntry.SubItems.Count == 1)
            {
                listEntry.SubItems.Add(fileItem.Status);
                listEntry.SubItems.Add(fileItem.FileHashMd5);
                listEntry.SubItems.Add(fileItem.IsProcessed.ToString());
            }
            else
            {
                listEntry.SubItems[1].Text = fileItem.Status;
                listEntry.SubItems[2].Text = fileItem.FileHashMd5;
                listEntry.SubItems[3].Text = fileItem.IsProcessed.ToString();
            }

            return;
        }

        listEntry = new ListViewItem
        {
            Name = fileItem.FilePath,
            Text = fileItem.FilePath
        };
        listEntry.SubItems.Add(fileItem.Status);
        listEntry.SubItems.Add(fileItem.FileHashMd5);
        listEntry.SubItems.Add(fileItem.IsProcessed.ToString());
        if (rowColor is not null)
            listEntry.ForeColor = rowColor.Value;
        listView.Items.Add(listEntry);
    }
    
    public static void DisableCloseButton(IntPtr handle)
    {
        var hMenu = GetSystemMenu(handle, false);
        var count = GetMenuItemCount(hMenu);
        RemoveMenu(hMenu, count - 1, MF_BYPOSITION);
    }
    
    public static void EnableCloseButton(IntPtr handle)
    {
        GetSystemMenu(handle, true);
    }
}