let gyroscope = new Gyroscope({frequency: 100});
let laSensor = new LinearAccelerationSensor({frequency: 100});

gyroscope.addEventListener('reading', (e) => {
  console.log(`Asse X: ${gyroscope.x}`);
  console.log(`Asse Y: ${gyroscope.y}`);
  console.log(`Asse Z: ${gyroscope.z}`);
});

laSensor.addEventListener('reading', (e) => {
  console.log(`Accelerazione Lineare Lungo l'Asse X: ${laSensor.x}`);
  console.log(`Accelerazione Lineare Lungo l'Asse X: ${laSensor.y}`);
  console.log(`Accelerazione Lineare Lungo l'Asse X: ${laSensor.z}`);
});

gyroscope.start();
laSensor.start();