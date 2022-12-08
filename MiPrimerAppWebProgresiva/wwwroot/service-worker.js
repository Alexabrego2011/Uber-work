var nombreCacheEstaticos = "cacheEstaticos1"
var nombreCacheDinamico = "cacheDinamico1"
var archivosEstaticos = ["/css/menu.css","/MiPrimerAppWebProgresiva.styles.css",
    "/lib/jquery/dist/jquery.min.js",
    "/lib/bootstrap/dist/js/bootstrap.bundle.min.js",
    "/js/menu.js", "/", "/js/generic.js", "/img/loading.gif",
    "/Persona/ListaPersonas", "/PaginaError/Index"]

self.addEventListener("install", event => {
    console.log("Evento Install")
    event.waitUntil(
        caches.open(nombreCacheEstaticos).then(cache => {
            return cache.addAll(archivosEstaticos)
        })
    )
})

self.addEventListener("activate", event => {
    console.log("Evento Activate")
    event.waitUntil(self.clients.claim())
})

self.addEventListener("fetch", event => {

    const respuesta = caches.match(event.request).then(res => {
        if (res) return res;
        else {
            return fetch(event.request).then(response => {
                caches.open(nombreCacheDinamico).then(cache => {
                    cache.put(event.request, response)
                })
                return response.clone();
            })
        }
    }).catch(err => {

        if (event.request.headers.get("accept").includes("text/html")) {
            return caches.match("/PaginaError/Index")
        } else {
            var responce = new Response('<h1 class="text-danger">Para realizar esta accion se necesita internet</h1>'
                , {
                    headers: {
                        "Content-Type": "text/html"
                    }
                })
            return responce;
        }
    })

    //if (event.request.url == "https://localhost:7147/css/menu.css") {
    //    event.respondWith(null);
    //}
    //else {
    //}
    //console.log(event.request.url)
    event.respondWith(fetch(event.request.url))
    
})