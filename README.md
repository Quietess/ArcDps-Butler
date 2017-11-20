# ArcDps Butler

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/M4xZ3r0/GW2RaidTool/master/LICENSE)

[![GitHub issues](https://img.shields.io/github/issues/Pikl/ArcDps-Butler.svg)](https://github.com/Pikl/ArcDps-Butler/issues)
[![GitHub issues](https://img.shields.io/github/issues-closed/Pikl/ArcDps-Butler.svg)](https://github.com/Pikl/ArcDps-Butler/issues?utf8=%E2%9C%93&q=is%3Aissue%20is%3Aclosed)

## Description
Originally named GW2 Raid Tool by M4xZ3r0, "enhanced" and renamed by Pikl.

ArcDps Butler is used for automatically parsing newly created ArcDps files and display the results for the user.
In order to do this the application uses a modified version of the EVTC log parser and RaidHeroes.
In addition, Butler can upload log files to DPS.Report, GW2 Raidar, and post the DPS.Report links in a specified Discord channel.

## Special Thanks
[RaidHeroes](https://raidheroes.tk)
[GW2 Raidar](https://www.gw2raidar.com)
[DPS.Report](https://dps.report)
[EVTC Log Parser](https://github.com/phoenix-oosd/EVTC-Log-Parser)

## Installation
- Download the application from here: [latest version (1.1.0)](https://github.com/Pikl/ArcDps-Butler/raw/master/Versions/1.1.0/ArcDps Butler 1.1.0.zip)
- Unzip the content
- Run the "ArcDps Butler.exe" file

## Workflow
So if you ask yourself "What the hell is this thing doing?" here is a small list:
- Keeps an eye on the ArcDps log file folder
- As soon as a new file is detected / imported it is parsed by the modified EVTC log parser
- Afterwards the same file is parsed by RaidHeroes and the html file saved to a defined location (optional)
- After that, the evtc file is uploaded to GW2 Raidar (optional)
- At this point you may post the logs into a specified discord channel through a bot user.

## Manual
### Main view
The main view is divided into 4 parts:
- the button area
- the encounter list
- the details area
- the log area

#### Button area
You can manually import evtc and evtc.zip files by using the add button, 
The clear button will let you remove a single encounter.
The clear all button will remove all encounters, even the currently filtered ones.
There exists a button for each Upload to DPS.Report, GW2 Raidar and Discord.
All of the upload/post buttons will only upload/post encounters once, and will not upload/post filtered logs.

#### Encounter list
The encounter list shows all parsed encounters. Newly added encounters are automatically selected.
By double clicking on the encounter you can open the RaidHeros html file (as soon as it is available).

#### Details area
The details area shows basic stats for the characters that have been present in the encounter.

#### Log area
The log area is collapsed by default, it informs you what the application is currently doing.

### Settings
To open the options panel press the settings icon at the top right.