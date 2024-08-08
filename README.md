# One Track is a Vehicle Management Application written in C#.

## Features:

OT.Blazor: Blazor Frontend
  Calls the NHTSA API for VIN lookup.  Some data returned is not 100% accurate to what the door label may say. Testing with my personal truck finds the GVWR and Transmission Speeds to be inaccurate.
  This returns limited information right now as I am just starting and verifying funcionallity as I am going.    

OT.Api: Api Backend
  This is the main backend for the application.  It has not been started yet.

### List of Returned Variables From The NHTSA API:
(Header Name) Variable
Suggested VIN
Error Code
Possible Values
Additional Error Text
Error Text
Vehicle Descriptor
Make
Manufacturer Name
Model
Model Year
Plant City
Series
Trim
Vehicle Type
Plant Country
Plant State
Body Class
Doors
Gross Vehicle Weight Rating From
Cab Type
Trailer Type Connection
Trailer Body Type
Number of Wheels
Wheel Size Front (inches)
Wheel Size Rear (inches)
Number of Seats
Number of Seat Rows
Transmission Speeds
Drive Type
Brake System Type
Engine Number of Cylinders
Displacement (CC)
Displacement (CI)
Displacement (L)
Engine Model
Fuel Type - Primary
Engine Configuration
Turbo
Seat Belt Type
Curtain Air Bag Locations
Front Air Bag Locations
Side Air Bag Locations
Anti-lock Braking System (ABS)
Electronic Stability Control (ESC)
Traction Control
Tire Pressure Monitoring System (TPMS) Type
Auto-Reverse System for Windows and Sunroofs
Keyless Ignition
Crash Imminent Braking (CIB)
Blind Spot Warning (BSW)
Forward Collision Warning (FCW)
Lane Departure Warning (LDW)
Backup Camera
Parking Assist
Bus Floor Configuration Type
Bus Type
Custom Motorcycle Type
Motorcycle Suspension Type
Motorcycle Chassis Type
Dynamic Brake Support (DBS)
Daytime Running Light (DRL)
Headlamp Light Source
Semiautomatic Headlamp Beam Switching
Adaptive Driving Beam (ADB)
Rear Cross Traffic Alert

![VinLookup](https://github.com/user-attachments/assets/263afd00-9c59-4dab-a287-842eedc0c003)
