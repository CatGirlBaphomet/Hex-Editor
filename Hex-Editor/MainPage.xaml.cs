using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Hex_Editor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private StorageFile currentFile;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a file picker dialog to select a file
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".txt"); // You can keep other allowed types (if needed)

            // Add support for .exe and .dll files
            picker.FileTypeFilter.Add(".exe");
            picker.FileTypeFilter.Add(".dll");

            // Show the file picker and get the selected file
            currentFile = await picker.PickSingleFileAsync();
            if (currentFile != null)
            {
                // Display the selected file's path in the FileLocationText
                FileLocationText.Text = "Current File: " + currentFile.Path;
            }
            // You can remove the else block since the initial content is set in XAML
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear the FileLocationText
            FileLocationText.Text = "Current File: No file selected";

            // Clear the currentFile reference
            currentFile = null;
        }

    }
}
