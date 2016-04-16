# CTEC708 Matter VR Music Controller

![logo](https://github.com/waltzaround/CTEC708-VR-Controller/blob/master/images/logo.png "logo")


VR music controller that requires an Oculus DK2 headset and a Leap Motion sensor to function.

We have a [public Trello board](https://trello.com/b/lQ19QmZj/matter) available for viewing upcoming 
features and checking the progress of bug fixes.

##Setup Instructions

Make sure you are running Unity `5.3.4` as this is the most compatible version with this project to date.

###Dependencies

- An Oculus Rift DK2 headset and the [requisite runtime](https://developer.oculus.com/downloads/)
- A Leap Motion Sensor with the [requisite runtime](https://developer.leapmotion.com/get-started)
- An install of the [Unity Game Engine](https://unity3d.com/get-unity/download)

##Instructions

- Refer to the `Dynamic Visualizer` folder for the current build with Leap Motion integration and audio analysis
- Refer to the `Kinect Test` folder for an abandoned attempt to build it with the Kinect 2 SDK
- Refer to the `UnityOSCTest` folder for the repo we tried to use to sync with LiveOSC 

##Academic Project Compliance (Lecturers, look here please)

Hello Lecturers! This section will be relevant to you :)

The purpose of this project is to create an interactive VR interface with the Oculus Rift and Leap Motion.
We seek to explore new applications of VR technology and the potential to extend the boundaries of human-computer interaction or HCI. Exploration will be conducted with a specific focus on audio production, using VR interfaces.

###Timeline:

####Week 1 - Onboarding

The first week was spent onboarding team members onto some tools (Github, SourceTree, Unity, Trello) and build processes that were essential to collaborating together on a software project. Development began slowly as ideas were drafted and conceptualized as low-fidelity models on paper.  

[Commit - Team formation](https://github.com/waltzaround/CTEC708-VR-Controller/commit/87b89f97577776e13be141a01cbd0e7725c7ba1b)

[Commit - Unity Project Initialized](https://github.com/waltzaround/CTEC708-VR-Controller/commit/85324f10db75517f170f8297c98f62bdbfae6909)

####Week 2 - Prototyping with Kinect

We began developing the project around the Kinect 2 SDK, and succeeded in building an early prototype that demonstrated interaction in VR between a user and a virtual keyboard. However, working with the SDK proved to be difficult as the data quality the sensor provided was dismally subpar. Thumbs would disappear and reappear momentarily even though the sensor had direct line of sight to user's body parts. Even with a single user, the sensor would lose track of the user every few minutes. We realized then that it was unsuitable for our project.

![prototype 1](https://github.com/waltzaround/CTEC708-VR-Controller/blob/master/images/12980384_1116154471769855_1160455269_n.png "Prototype 1")


[Commit - Initial scoping with the kinect](https://github.com/waltzaround/CTEC708-VR-Controller/commit/3507f81dd3598529ed9bacec0ca916863f719cc1)

[Commit - Virtual Keyboard](https://github.com/waltzaround/CTEC708-VR-Controller/commit/e7851e369f91fc017788ff4c336bc4d8e2edf0df)

[Commit - Virtual Keyboard Audio](https://github.com/waltzaround/CTEC708-VR-Controller/commit/0d0bc46178db2cc9f63ecc743c4015b09c49b5ac)

####Weeks 3-4 - MIDI Integration Failure

After an immense amount of trial and error, we discovered that the LiveOSC Plugin were were dependent on to interface Ableton MIDI software with our Unity Engine Project was no longer functional. We decided to scrap MIDI support as none of our team had the technical skills or time to acquire them to fix the plugin. We opted to fall back to using Unity's audio methods to ensure the project ran to completion within the deadline. We became acquainted with the OSC protocol during this time.

- implementing plugins and how relying on external plugins is a dangerous move ie: you base an entire project on a plugin you find that doesn't end up working because there is no real way to debug or test or even check that the code is running :(

[Commit - UnityOSC boilerplate code](https://github.com/waltzaround/CTEC708-VR-Controller/commit/089f395ea1065b7a76675569905e2fe6a55c5578)

####Week 5 Leap Motion & Audio Analysis

We discovered that the Leap Motion SDK & hardware tracking was much more accurate despite it's flaws, and reached the conclusion we should implement the Leap SDK instead of the Kinect. We also discovered a 


####Week 6 UI Integrations

We developed a UI Prototype

![Leap Motion prototype controller](https://github.com/waltzaround/CTEC708-VR-Controller/blob/master/images/13023358_1116154475103188_1700030371_n.png "Prototype controller")


####Week 7 hackathon & Formative

Bugs in pushing and pulling
deveoping

- project management here







Files created for the CTEC708 Studio V paper at Auckland University of Technology


## Licence

###THE BEER-WARE LICENSE (Revision 42):

[Walter Lim](mailto:waltissomewhere@gmail.com), [Patricia Tan](mailto:thr2185@autuni.ac.nz), [Thomas Louden](mailto:ktj9551@autuni.ac.nz), and [Chris Liu](mailto:christopherliu97@gmail.com) cobbled this project together.  As long as you retain this notice you can do whatever you want with this stuff. If we meet some day, and you think this stuff is worth it, you can buy any of us a beer in return.

