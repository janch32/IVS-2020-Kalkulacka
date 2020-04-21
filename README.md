# IVS Calculator

Team project for IVS course. Simple calculator for windows.

[Project assignment](http://ivs.fit.vutbr.cz/projekt-2_tymova_spoluprace2019-20.html) (in czech)

## Installation


To install application from installer you simply need to run it and follow setup steps. To uninstall the aplication you need to go to `Control Panel\Programs\Programs and Features` and uninstall it from there. For more information see user documentation.

## Build

To be able to build this program with `Makefile`, you need to have `.NET Core 3.1`. You can get it by installing [Visual Studio](https://visualstudio.microsoft.com/) with Individual component `.NET Core 3.1`, or if you don't want to install Visual Studio you can just install [.NET core](https://dotnet.microsoft.com/download/dotnet-core/3.1)

### GNU Make
First thing you need to do to be able to run Makefile is to download and install GNU Make for Windows.
You can download it at:
http://gnuwin32.sourceforge.net/packages/make.htm,
then install it. Instalation guide is available on their web.

After installing it you need to edit Environment variable Path. 
To do this simply type path into search bar and open `Edit the system environment variables`. 
Then click on `Environment Variables...` in the bottom right corner. 
After that click on `Path` in `User variables for *user_name* ` and click on `Edit...`. 
Then click on `Browse` and find your `GnuWin32` instalation folder, expand it and click on bin. 
After that click `ok`.

### GNU Zip
To be able to use `make zip` instruction, you need to download and install Gnu ZIP.
You can download it at:
http://gnuwin32.sourceforge.net/packages/zip.htm.
Then install it same as GNU Make.

Now you are able to run aplication from makefile. To build and run it simply type `make` in `src` folder. For more information about make run `make help`.


## Authors
- Jan Chaloupka (`xchalo16`)
- Michal Halabica (`xhalab00`)
- Marek Václavík (`xvacla26`)
- Richard Hrmo (`xhrmor00`)

## Enviroment
Windows 64bit

## License
MIT licence, see file [LICENSE](/LICENSE) at the root of the repository.