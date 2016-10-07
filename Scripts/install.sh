#! /bin/sh
# Example install script for Unity3D project. See the entire example: https://github.com/JonathanPorta/ci-build
# This link changes from time to time. I haven't found a reliable hosted installer package for doing regular
# installs like this. You will probably need to grab a current link from: http://unity3d.com/get-unity/download/archive


echo 'Downloading from http://download.unity3d.com/download_unity/cc9cbbcc37b4/MacEditorInstaller/Unity-5.3.1f1.pkg: '
curl -o Unity.pkg http://download.unity3d.com/download_unity/cc9cbbcc37b4/MacEditorInstaller/Unity-5.3.1f1.pkg

echo 'Downloading from http://download.unity3d.com/download_unity/cc9cbbcc37b4/MacEditorTargetInstaller/UnitySetup-Mac-Support-for-Editor-5.3.1f1.pkg: '
curl -o Unity_mac.pkg  http://download.unity3d.com/download_unity/cc9cbbcc37b4/MacEditorTargetInstaller/UnitySetup-Mac-Support-for-Editor-5.3.1f1.pkg

echo 'Downloading from http://download.unity3d.com/download_unity/cc9cbbcc37b4/MacEditorTargetInstaller/UnitySetup-Linux-Support-for-Editor-5.3.1f1.pkg: '
curl -o Unity_linux.pkg http://download.unity3d.com/download_unity/cc9cbbcc37b4/MacEditorTargetInstaller/UnitySetup-Linux-Support-for-Editor-5.3.1f1.pkg

echo 'Downloading from http://download.unity3d.com/download_unity/cc9cbbcc37b4/MacEditorTargetInstaller/UnitySetup-Windows-Support-for-Editor-5.3.1f1.pkg: '
curl -o Unity_windows.pkg  http://download.unity3d.com/download_unity/cc9cbbcc37b4/MacEditorTargetInstaller/UnitySetup-Windows-Support-for-Editor-5.3.1f1.pkg

echo 'Installing Unity.pkg'
sudo installer -dumplog -package "Unity.pkg" -target /
sudo installer -dumplog -package "Unity_mac.pkg" -target /
sudo installer -dumplog -package "Unity_linux.pkg" -target /
sudo installer -dumplog -package "Unity_windows.pkg" -target /
