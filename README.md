# SaccadeVR-mobile:

A software package on Unity to use HTC VIVE Pro Eye, a head-mounted display with virtual reality technology, for assessment of saccadic eye movement.


## Installation:

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.


## Summary of programming algorithm:

The following diagram explains the programming algorithm to measure saccadic eye movement. The programme is developed using C# programming language on Unity. We use the version 2 in SRanipal SDK to measure the eye movement and to enable eye data callback function to continue to record the data of ocular movement independently of the main thread of the programme. *SRanipal_Eye_Framework.cs* provided in the SRanipal SDK needs to be linked with the Unity project to enable the eye tracking function. In the main programme, after Unity project starts to play, we check whether the whole system of eye tracking and VR headset work properly, perform the default calibration of eye tracking with five points, and start to record the eye movement. The measurement of eye movement is conducted using a callback function to separate the process of recording eye movement from the main programming thread of Unity. Once void Start() is completed, void Update() starts. We use a Coroutine function on Unity to execute the saccade tasks. In each saccade trial, Unix time is also recorded on Unity to understand what time each trial of saccadic eye movement measurement starts (i.e. to record the time when the red target appears on the user view of VR). Timestamp recorded by SRanipal SDK is not used due to the defect. When all the saccade tasks are completed, the programme records the last Unix time from the computer and then stops playing Unity. On the other hand, another programme thread of Eye Callback continues to record the ocular movement at the sampling frequency of 120 Hz, while void Update() is running. The thread of Eye Callback keeps checking whether the last Unix time is recorded in void Update(). Once Eye Callback thread confirms the record of the last Unix time, it also stops recording the eye movement three seconds after the confirmation. Finally, all the processes end.

<img src="Image/Saccade_VR_programme_algorithm.jpg" width="70%">


## Code contributors:

The code was originally developed by [Yu Imaoka](https://github.com/imarin18) and Andri Flury.


## License:

This project is licensed under the GNU Lesser General Public License v3.0 - see the [LICENSE](LICENSE) file for details.

