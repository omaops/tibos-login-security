# Tibos Login Security
## Introduction
This is a simple application you can put into your system and add it to your start up. When ever you or ... other people login to your windows matchine, it will show up a simple window that tells the user that activation for "Green Antivirus" failed and auto closes in 3 seconds.
In those 3 seconds, the app will activate the webcam, take a picture of the user, saves it to the path C:\Users\Public\Music\yoo with the date and time (yyyyMMdd-HHmmss.jpg) and closes as if nothing happened. 
This is a start and I will add a lot of login related security features in the future.

## How to setup
1. Download the app from the release page OR compile it from source.
2. Store the application folder in any location you prefer (Avoid folders like program Files that require admin access)
3. Right click on GreenAV.exe and create a short cut to your desktop
4. Cut the shortcut from your desktop (You copy it if you want) and paste it to
   - Windows 10: C:\Users\<your username>\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup
   - Windows 11: C:\Users\<your username>\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startups
5. From now own every time you boot into your windows, it will pop-up and do its work.
6. You can find the screenshots in C:\Users\Public\Music\yoo\

## Few things to Note
1. This works for windows 10 and 11 (Have not tested in on pervious version)
2. Add the app to your antivirus exception if it treats it as a spyware. You can compile it from the source code if needed.
3. Might need to be run as admin since it opens the active webacam (right click on GreenAV.exe -> Properties -> Compatability -> check the run as administrator checkbox)
4. Just in case you do not have it installed, get .Net Runtime 6.0 or Higher

### Cheers!
