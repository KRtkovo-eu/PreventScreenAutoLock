# PreventScreenAutoLock
Small application for Windows workstations which prevents screen autolock.

Idea:
All Windows laptops in our company has the policy that after 15 minutes, the workstation is locked by password. I understand that some of my colleagues never locked their computer so admin set this for all computers, however I feel unfree.
The main reason to make this app was to play ElectricSheep visualizations without showing lock screen each 15 minutes.

Other apps which brings the same feature are unfortunately unusable because they implemented keystrokes or mouse movement in some predefined interval. This application uses the same logic as Media player - it tells to operating system, that it should prevent screen from locking by SetThreadExecutionState method.
