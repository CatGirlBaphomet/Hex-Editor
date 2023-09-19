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
using Windows.ApplicationModel.DataTransfer;
using System.Threading.Tasks;
using Windows.UI.Text;
using Windows.Storage.Streams;
using System.Text;
using System.Threading;
using Windows.UI.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Hex_Editor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private StorageFile currentFile;
        private int totalBitsToLoad = 1000000;
        private int searchIndex = -1;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a file picker dialog to select a file
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".exe");
            picker.FileTypeFilter.Add(".dll");

            // Show the file picker and get the selected file
            currentFile = await picker.PickSingleFileAsync();
            if (currentFile != null)
            {
                // Display the selected file's path in the FileLocationText
                FileLocationText.Text = currentFile.Path;

                // You can load and display the file content in the hex view here
                // Example: HexView.ItemsSource = LoadHexDataFromFile(currentFile);
            }
        }

        private void FileLocationBox_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FileLocationText.Text))
            {
                // Copy the file location text to the clipboard
                var dataPackage = new DataPackage();
                dataPackage.SetText(FileLocationText.Text);
                Clipboard.SetContent(dataPackage);

                // Show a notification or update the status text to indicate that the text is copied
                StatusText.Text = "File location copied to clipboard.";
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentFile != null)
            {
                // You can implement the logic to save the edited hex data to the currentFile
                // Example: SaveHexDataToFile(currentFile, GetEditedHexData());
                StatusText.Text = "File saved.";
            }
            else
            {
                StatusText.Text = "No file to save.";
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear the FileLocationText
            FileLocationText.Text = "";

            // Clear the currentFile reference
            currentFile = null;
        }


        private async void SearchTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text;

            // Ensure the BitsRichEditBox (or whichever control you want to search) is not null
            if (BitsRichEditBox != null)
            {
                // Perform the search based on the entered text
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    ITextDocument textDocument = BitsRichEditBox.Document;
                    string documentText;
                    Windows.UI.Text.TextGetOptions options = Windows.UI.Text.TextGetOptions.None;

                    // Get the document text
                    textDocument.GetText(options, out documentText);

                    // Search for the text starting from the current selection position
                    int index = documentText.IndexOf(searchText, searchIndex + 1, StringComparison.OrdinalIgnoreCase);

                    if (index >= 0)
                    {
                        // Found a match, select the text
                        textDocument.Selection.StartPosition = index;
                        textDocument.Selection.EndPosition = index + searchText.Length;
                        BitsRichEditBox.Focus(FocusState.Programmatic);

                        // Update searchIndex
                        searchIndex = index;
                    }
                    else
                    {
                        // No more matches, reset searchIndex
                        searchIndex = -1;
                    }
                }
                else
                {
                    // Clear search results and selection if the search box is empty
                    ITextSelection textSelection = BitsRichEditBox.Document.Selection;
                    textSelection.StartPosition = textSelection.EndPosition = 0;
                    BitsRichEditBox.Focus(FocusState.Programmatic);
                    searchIndex = -1;
                }
            }

        }


        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text;

            // Ensure the BitsRichEditBox (or whichever control you want to search) is not null
            if (BitsRichEditBox != null)
            {
                ITextDocument textDocument = BitsRichEditBox.Document;
                string documentText;
                Windows.UI.Text.TextGetOptions options = Windows.UI.Text.TextGetOptions.None;

                // Get the document text
                textDocument.GetText(options, out documentText);

                // Search for the text starting from the current selection position + 1
                int index = documentText.IndexOf(searchText, searchIndex + 1, StringComparison.OrdinalIgnoreCase);

                if (index >= 0)
                {
                    // Found a match, select the text
                    textDocument.Selection.StartPosition = index;
                    textDocument.Selection.EndPosition = index + searchText.Length;
                    BitsRichEditBox.Focus(FocusState.Programmatic);

                    // Update searchIndex
                    searchIndex = index;
                }
                else
                {
                    // No more matches, reset searchIndex
                    searchIndex = -1;
                }
            }
        }

        private async void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text;

            // Ensure the BitsRichEditBox (or whichever control you want to search) is not null
            if (BitsRichEditBox != null)
            {
                ITextDocument textDocument = BitsRichEditBox.Document;
                string documentText;
                Windows.UI.Text.TextGetOptions options = Windows.UI.Text.TextGetOptions.None;

                // Get the document text
                textDocument.GetText(options, out documentText);

                // Search for the text in the reverse direction, starting from the current selection position - 1
                int index = documentText.LastIndexOf(searchText, searchIndex - 1, StringComparison.OrdinalIgnoreCase);

                if (index >= 0)
                {
                    // Found a match, select the text
                    textDocument.Selection.StartPosition = index;
                    textDocument.Selection.EndPosition = index + searchText.Length;
                    BitsRichEditBox.Focus(FocusState.Programmatic);

                    // Update searchIndex
                    searchIndex = index;
                }
                else
                {
                    // No more matches in reverse direction, reset searchIndex
                    searchIndex = -1;
                }
            }
        }


        private async void LoadBitsButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear the RichEditBox
            BitsRichEditBox.Document.SetText(TextSetOptions.None, "");

            // Display loading message
            StatusText.Text = "Loading bits...";

            try
            {
                if (currentFile != null)
                {
                    const int bufferSize = 10000; // Number of bits to load and display at once
                    byte[] buffer = new byte[bufferSize];
                    long totalBytesRead = 0;
                    long totalFileSize = (long)(await currentFile.GetBasicPropertiesAsync()).Size;

                    using (var fileStream = await currentFile.OpenReadAsync())
                    {
                        int bytesRead;
                        StringBuilder bitsWithSpaces = new StringBuilder();
                        int bitsLoaded = 0;

                        do
                        {
                            var bufferRead = new Windows.Storage.Streams.Buffer(bufferSize);
                            var result = await fileStream.ReadAsync(bufferRead, (uint)bufferSize, InputStreamOptions.None);
                            bytesRead = (int)result.Length;

                            DataReader dataReader = DataReader.FromBuffer(result);
                            dataReader.ReadBytes(buffer);

                            for (int i = 0; i < bytesRead; i++)
                            {
                                bitsWithSpaces.Append(buffer[i].ToString("X2")); // Convert byte to hex string
                                bitsWithSpaces.Append(" "); // Add a space between every bit

                                bitsLoaded++;

                                if (bitsLoaded % 16 == 0)
                                {
                                    bitsWithSpaces.AppendLine(); // Start a new line every 16 bits
                                }
                            }

                            // Update the RichEditBox contents and progress every 10,000 bits
                            if (bitsLoaded % 10000 == 0)
                            {
                                BitsRichEditBox.Document.Selection.SetText(TextSetOptions.None, bitsWithSpaces.ToString());
                                bitsWithSpaces.Clear();

                                // Calculate and display progress as a percentage
                                double progress = (double)totalBytesRead / totalFileSize * 100;
                                StatusText.Text = $"Loading bits... {progress:F2}%";
                            }

                            totalBytesRead += bytesRead;
                        } while (bytesRead > 0);

                        // Update any remaining bits
                        if (bitsWithSpaces.Length > 0)
                        {
                            BitsRichEditBox.Document.Selection.SetText(TextSetOptions.None, bitsWithSpaces.ToString());
                        }
                    }

                    // Clear the loading message
                    StatusText.Text = "Bits loaded.";
                }
                else
                {
                    StatusText.Text = "No file selected.";
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the process
                StatusText.Text = "Error loading bits: " + ex.Message;
            }
        }


        private void ApplyBitsButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the text from the BitsRichEditBox
            string bitsText = BitsRichEditBox.Document.Selection.Text;

            // Implement your logic to apply the bits here
            // For now, let's display a message with the applied bits
            string appliedBits = ApplyBitsLogic(bitsText); // Replace with your logic

            // Display a message with the applied bits
            StatusText.Text = "Applied Bits: " + appliedBits;
        }

        // Example logic to apply bits (replace with your actual logic)
        private string ApplyBitsLogic(string bits)
        {
            // You can process and manipulate the bits here
            // For this example, we'll just return the original bits
            return bits;
        }





        private void LoadBytesButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement the Load Bytes functionality
        }

        private void ApplyBytesButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement the Apply Bytes functionality
        }

        private void LoadHexButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement the Load Hex functionality
        }

        private void ApplyHexButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement the Apply Hex functionality
        }

        private void LoadTextButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement the Load Text functionality
        }

        private void ApplyTextButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement the Apply Text functionality
        }

        // Event handler for the FillCheckBox checkbox (if you want to handle its state change)
        private void FillCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox fillCheckBox = (CheckBox)sender; // Cast the sender to a CheckBox

            if (fillCheckBox.IsChecked == true)
            {
                // The "Fill" checkbox is checked, so enable the fill behavior

                // Example: Implement fill behavior by filling the BitsRichEditBox with a pattern
                string fillPattern = "FF "; // You can change this to your desired fill pattern
                StringBuilder filledBits = new StringBuilder();

                for (int i = 0; i < totalBitsToLoad; i++)
                {
                    filledBits.Append(fillPattern);

                    // Add a new line every 16 bits for readability
                    if ((i + 1) % 16 == 0)
                    {
                        filledBits.AppendLine();
                    }
                }

                // Set the text in the BitsRichEditBox to the filled pattern
                BitsRichEditBox.Document.SetText(TextSetOptions.None, filledBits.ToString());

                // Update status text
                StatusText.Text = "Fill enabled";

                // Perform additional actions when fill is enabled
            }
            else
            {
                // The "Fill" checkbox is unchecked, so disable the fill behavior

                // Clear the BitsRichEditBox text
                BitsRichEditBox.Document.SetText(TextSetOptions.None, "");

                // Update status text
                StatusText.Text = "Fill disabled";

                // Perform additional actions when fill is disabled
            }
        }


        // Event handler for the CapsLockCheckBox checkbox (if you want to handle its state change)
        private void CapsLockCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Handle checkbox checked state
        }
    }

}