#! /bin/sh

sed -i -e "s/<versionnumber>/$(git describe)/g" Assets/scripts/VersionTag.cs

# Example build script for Unity3D project. See the entire example: https://github.com/JonathanPorta/ci-build
# Change this the name of your project. This will be the name of the final executables as well.
project="gamejam-0.2"

echo "Attempting to build $project for Windows"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
    -batchmode \
      -nographics \
        -silent-crashes \
          -logFile $(pwd)/unity.log \
            -projectPath $(pwd) \
              -buildWindowsPlayer "$(pwd)/Build/windows/$project.exe" \
                -quit

cat unity.log

echo "Attempting to build $project for OS X"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
    -batchmode \
      -nographics \
        -silent-crashes \
          -logFile $(pwd)/unity.log \
            -projectPath $(pwd) \
              -buildOSXUniversalPlayer "$(pwd)/Build/osx/$project.app" \
                -quit

cat unity.log

echo "Attempting to build $project for Linux"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
    -batchmode \
      -nographics \
        -silent-crashes \
          -logFile $(pwd)/unity.log \
            -projectPath $(pwd) \
              -buildLinuxUniversalPlayer "$(pwd)/Build/linux/$project.exe" \
                -quit

cat unity.log

cd Build

hdiutil create -fs HFS+ -srcfolder "osx" -volname "gamejam-0.2-osx" "gamejam-0.2-osx.dmg"
zip -r "gamejam-0.2-windows.zip" "windows"
zip -r "gamejam-0.2-linux.zip" "linux"
