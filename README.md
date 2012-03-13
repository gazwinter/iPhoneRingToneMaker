# iPhoneRingToneMaker

## Overview

iPhoneRingToneMaker is an application created in C# to take file and convert it into a valid iPhone ringtone.

Choose an MP3 file from your PC and it will convert it into a valid iPhone ringtone. (Currently by using the first 30 seconds of the track)

## Features

### YouTube converter

iPhoneRingToneMaker takes a specified YouTube video, downloads it and converts it to MP3.
Currently there is a small problem with this. You need to manually edit the MP3 title, artist etc.
This currently saves a file called extracted.mp3 to a folder on the users desktop called temp.

### Ringtone Creation

This requires iTunes to be installed. The program will open an MP3 file, convert it using iTunes to the M4a format, then turn it into a 30 second iPhone tone. You will need to sync your iPhone with iTunes once the ringtone is created.

## Requirements
 •	.NET Framework 4.0;
 
 •	[YouTubeExtractor](https://github.com/flagbug/YoutubeExtractor) developed by [flagbug](https://github.com/flagbug);
 
 •	iTunes 7+;
 
## Development

iPhoneRingToneMaker is currently has to be compiled from the source code. Once all the bugs are ironed out i will create an installer.
