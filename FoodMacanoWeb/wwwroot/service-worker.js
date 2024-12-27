// En desarrollo, siempre obtener desde la red y no habilitar soporte offline.
// Esto se debe a que el almacenamiento en caché haría el desarrollo más difícil (los cambios no se
// reflejarían en la primera carga después de cada cambio).
self.addEventListener('fetch', (event) => { });