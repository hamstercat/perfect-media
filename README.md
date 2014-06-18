perfect-media
=============

[XBMC](http://www.xbmc.org) unoficial content manager for media including TV Shows, Movies and Music!

_This application is still a work in progress, use at your own risk. If you already have .nfo files and fanart you want to keep with your media, please make a backup of it before using perfect-media._

# Purpose

perfect-media let's you organize your media files before importing them in XBMC to receive the optimal experience everytime! To do so, it will create .nfo files and download images beside your media files that XBMC will then import when you add them to your library. While perfect-media automatically download information from the internet, it also allows you to change any information or image after it has finished, so you're in control of how XBMC looks like at the end.

It can retrieve information from the following sources automatically:
- Existing local .nfo files and images
- thetvdb.org

# How to install

There is no compiled version of perfect-media yet, you will have to build it from sources to try it. To do so, follow these steps:

1. First, make sure you have the following requirements installed on your computer:
    - Windows OS
    - .NET 4.5 or higher installed
    - Visual Studio 2012 or higher
2. Open the solution PerfectMedia.sln found at the root of the repositories.
3. Build in Visual Studio (CTRL + B).
4. Run PerfectMedia.UI.exe.

A compiled version will be provided when a free continuous integration server for open-source C# project is found.

# License

perfect-media is licensed under the GPLv3 license.
