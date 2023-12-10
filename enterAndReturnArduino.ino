int contourCount = 0; // Variable to store contour count

// Arrays to store X and Y coordinates
int Xs[20]; // holds up to 100
int Ys[20];

void setup() {
    Serial.begin(9600); // Initialize serial communication
}

void loop() {
    if (Serial.available() > 0) {
        // Read the incoming data
        String receivedData = Serial.readStringUntil('\n');

        // Convert received data to an integer
        int dataValue = receivedData.toInt();

        if (!isnan(dataValue)) 
        {
            // Check if contour count is received
            if (contourCount == 0) 
            {
                contourCount = dataValue - 1;
                Serial.print("Received contour count: ");
                Serial.println(contourCount);
            } else {
                // Handle shape data (X and Y coordinates)
                Serial.println("Received shape data: " + receivedData);

                // Parse receivedData for X and Y coordinates as needed
                // For example, if your data is in the format "X,Y", you can do:
                int commaIndex = receivedData.indexOf(',');
                if (commaIndex != -1) 
                {
                    // Extract X and Y coordinates
                    int X = receivedData.substring(0, commaIndex).toInt();
                    int Y = receivedData.substring(commaIndex + 1).toInt();

                    // Store X and Y coordinates in arrays
                    Xs[contourCount - 1] = X;
                    Ys[contourCount - 1] = Y;

                    // Print the stored X and Y coordinates
                    Serial.println("Stored X: " + String(X) + ", Y: " + String(Y));

                    // Decrement the contour count
                    contourCount--;

                    // Check if all contours are received
                    if (contourCount == 0) 
                    {
                        Serial.println("All contours received.");
                        Serial.println("Stored X and Y coordinates:");
                     
                        for (int i = 0; i < 5; i++) 
                        {
                        Serial.print("Index " + String(i) + ": X = " + String(Xs[i]) + ", Y = " + String(Ys[i]));
                        Serial.println();
                         }

                        // Reset the contour count for the next set of data
                        contourCount = 0;
                    }
                }
            }
        } else 
        {
            // Handle the case when the received data is not a valid integer
            Serial.println("Received invalid data: " + receivedData);
        }
    }
}
