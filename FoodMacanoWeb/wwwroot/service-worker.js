// En desarrollo, siempre obtener desde la red y no habilitar soporte offline.
// Esto se debe a que el almacenamiento en cach� har�a el desarrollo m�s dif�cil (los cambios no se
// reflejar�an en la primera carga despu�s de cada cambio).
self.addEventListener('fetch', (event) => { });