# SaccadeVR-mobile:

A software package of Unity to use HTC VIVE Pro Eye, a head-mounted display with virtual reality technology, for assessment of saccadic eye movement.


## System set-up

###### Software version
The following software is used for the measurement system.
- Unity: 2019.2.5f1
- Steam VR: 1.11.11
- SRanipal, a software development kit for eye tracking provided by HTC: 1.1.0.1
- SR Runtim: 1.1.2.0

###### Set-up procedures
1. Open the folder of **SaccadeVR_ViveProEye** on Unity.
2. Go to Building Settings --> Player Settings --> Player --> XR Settings. Click *Virtual Reality Supported* to enable the VR configuration.
3. Start playing for the measurement.


## Files
###### Saccade_measure_rev1.cs
C# programming file to configure the measurement system. The file is found SaccadeVR_ViveProEye --> Assets --> Scripts.

###### DisableTracking.cs
C# programming file to disable the tracking of head movement of the VR headset. If the tracking is active, the position of the stimuli targets for saccade measurement changes when the user moves the head. The file is found SaccadeVR_ViveProEye --> Assets --> Scripts.

###### StandardSaccade_IDnumber.txt
Data of eye movement are recorded in this text file. The text file is created under the folder of **SaccadeVR_ViveProEye**
The measured parameters include
- Frame sequence
- Timestamp (ms)
- Gaze origin (mm)
- Gaze direction (normalised to between -1 and 1)
- Pupil position (normalised to between 0 and 1)
- Pupil diameter (mm)
- Eye openness (normalised to between 0 and 1)
- Validity of eye data

###### Saccade_Start_Time_IDnumber.txt
Unixtime of the computer is recorded in this text file when the saccade task starts in each saccade trial. With the recorded time, the latency (response time) of saccadic eye movement is calculated.


## Summary of programming algorithm:

The following diagram explains the programming algorithm to measure saccadic eye movement. The programme is developed using C# programming language on Unity. We use the version 2 in SRanipal SDK to measure the eye movement and to enable eye data callback function to continue to record the data of ocular movement independently of the main thread of the programme. *SRanipal_Eye_Framework.cs* provided in the SRanipal SDK needs to be linked with the Unity project to enable the eye tracking function. In the main programme, after Unity project starts to play, we check whether the whole system of eye tracking and VR headset work properly, perform the default calibration of eye tracking with five points, and start to record the eye movement. The measurement of eye movement is conducted using a callback function to separate the process of recording eye movement from the main programming thread of Unity. Once void Start() is completed, void Update() starts. We use a Coroutine function on Unity to execute the saccade tasks. In each saccade trial, Unix time is also recorded on Unity to understand what time each trial of saccadic eye movement measurement starts (i.e. to record the time when the red target appears on the user view of VR). Timestamp recorded by SRanipal SDK is not used due to the defect. When all the saccade tasks are completed, the programme records the last Unix time from the computer and then stops playing Unity. On the other hand, another programme thread of Eye Callback continues to record the ocular movement at the sampling frequency of 120 Hz, while void Update() is running. The thread of Eye Callback keeps checking whether the last Unix time is recorded in void Update(). Once Eye Callback thread confirms the record of the last Unix time, it also stops recording the eye movement three seconds after the confirmation. Finally, all the processes end.

<img src="Image/Saccade_VR_programme_algorithm.jpg" width="70%">

A sample VR design for the measurement of saccadic eye movement 

<img src="Image/Saccade_VR_sample.gif" width="70%">


## Code contributors:

The code was originally developed by [Yu Imaoka](https://github.com/imarin18) and [Andri Flury](https://github.com/Dawabenelona).


## License:

This project is licensed under the GNU Lesser General Public License v3.0 - see the [LICENSE](LICENSE) file for details.

