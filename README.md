# SnapshotDemo_WindowsForms

SnapshotDemo_WindowsForms is a Windows Forms application that allows users to capture screenshots of their desktop application windows and record their screen as a video. The application is built using C# and leverages the VisioForge library for screen capture and video recording functionalities.

## Features

- **Capture Screenshots:** With a simple click of a button, users can capture the current application window and save it as a PNG image.

- **Record Screen:** Users can start recording their screen, capturing all on-screen activities. The recorded video is saved in MP4 format.

- **Save Location:** All the captured screenshots and videos are saved in the `C:\snapshots` folder by default. The application automatically creates subfolders for screenshots and video recordings.

- **Open Folder:** Users can easily access the saved screenshots and video recordings by clicking the "Open Folder" button.

## How to Use

1. **Capture a Screenshot:**
   - Launch the SnapshotDemo_WindowsForms application.
   - Click the "Capture" button to capture the current application window.
   - The screenshot will be saved in the `C:\snapshots\Screenshots` folder.

2. **Record Screen:**
   - Click the "Start Recording" button to begin the screen recording.
   - All on-screen activities will be recorded.
   - To stop the recording, click the "Stop Recording" button.
   - The recorded video will be saved in the `C:\snapshots\Video_Records` folder.

3. **Access Saved Files:**
   - Click the "Open Folder" button to open the `C:\snapshots` folder.
   - Inside the folder, you will find the subfolders "Screenshots" and "Video_Records" containing your captured screenshots and recorded videos, respectively.

## Requirements

- Windows OS
- .NET Framework

## Installation

1. Clone this repository or download the project as a ZIP file.
2. Open the project in Visual Studio (or any other C# IDE).
3. Build and run the application.

## Dependencies

- VisioForge Video Capture SDK (Ensure it is properly referenced in the project)
