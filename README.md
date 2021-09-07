# paired-device-manager

This is a prototype of a tracking system that allows for
devices to be paired, removed and updated for a given dwelling. 

Device types:
1. Dwelling - A living space where hubs and devices can be installed
2. Hub - A hardware piece that interacts with devices
3. Devices

Device Types:

Switch -  A device that can be turned on and off
Dimmer - A device that provides variable lighting
Lock - A door lock that can be open/shut and can have a pin code to enter
Thermostat - A device for controlling the heat/cool levels of the dwelling

## Entities:

### Device
1. Create - Create a new device
2. Delete - Delete a device that is not currently paired
3. Info - Retrieve the current state of a device
4. Modify - Change the state of the device
5. List - List all devices
![image](https://user-images.githubusercontent.com/1232540/132280339-ba88c87f-3435-4a30-8c1f-413b1f1ee662.png)

### Hub
1. Pair Device - Pair a previously created device
2. Get Device State - Get information about a device as
3. List Devices - Get a list of devices paired to a hub
4. Remove Device - Unpair a device from a hub
![image](https://user-images.githubusercontent.com/1232540/132280443-0b40449b-aaff-4846-b8fb-65bfc61469f5.png)

### Dwelling
1. Occupied - A new resident has moved into the dwelling
2. Vacant - A resident no longer resides in the dwelling
3. Install Hub - Associate a hub with a dwelling
4. List Dwellings - Get a list of all dwellings
![image](https://user-images.githubusercontent.com/1232540/132280376-740ee21a-d123-4369-b267-a8635ed87145.png)

# Swagger UI
Swagger UI allows a user to explore an API and test it out. Each endpoint listed above is testable this way.
For example:
![image](https://user-images.githubusercontent.com/1232540/132280681-4c84ae34-b36d-48d5-8dde-2ce5778abf66.png)

# Projects in this solution
## PairedDeviceManager
## PairedDeviceManager.Api
## PairedDeviceManager.Contract
