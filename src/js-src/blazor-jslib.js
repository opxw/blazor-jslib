export function consoleLog(msg, showLog) {
    if (showLog) {
        console.log(msg);
    }
}

export function addJs(url, appendTo, isAsync, showLog) {
    const script = document.createElement('script');
    script.type = 'text/javascript';
    script.src = url;
    script.async = isAsync; // Load asynchronously

    if (appendTo == 0) {
        document.head.appendChild(script);
    } else {
        document.body.appendChild(script);
    }

    consoleLog('js {url} added to ({appendTo})');
}
export function addCss(url, appendTo, showLog) {
    //document.addEventListener('DOMContentLoaded', function () {
    //    var link = document.createElement('link');
    //    link.rel = 'stylesheet';
    //    link.href = url;

    //    if (appendTo == 0) {
    //        document.head.appendChild(link);
    //    } else {
    //        document.body.appendChild(link);
    //    }

    //    consoleLog('css {url} added to ({appendTo})', showLog);
    //});

    const link = document.createElement('link');
    link.rel = 'stylesheet';
    link.href = url;

    if (appendTo == 0) {
        document.head.appendChild(link);
    } else {
        document.body.appendChild(link);
    }

    consoleLog('css ${url} added to (${appendTo})', showLog);
 }

export function addClassById(elId, classes, showLog) {
    document.getElementById(elId).classList.add(classes);
    consoleLog('class ${classes} added to ${elId}', showLog);
}

export function remClassById(elId, classes, showLog) {
    document.getElementById(elId).classList.remove(classes);
    consoleLog('class ${classes} removed ${elId}', showLog);
}

export function addClassToBody(classes, showLog) {
    var clsNames = JSON.parse(classes);
  
    document.body.classList.add(clsNames);
    consoleLog('class ${clsNames} added to body', showLog);
}

export function remClassFromBody(classes, showLog) {
    document.body.classList.remove(classes);
    consoleLog('class ${classes} added to body', showLog);
}