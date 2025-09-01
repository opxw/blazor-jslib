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

    consoleLog('js ${url} added to (${appendTo})');
}
export function addCss(url, appendTo, showLog) {
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

 // elements

export function modClassBy(op, kind, identifier, className, showLog) {
    switch (kind) {
        case 1:
            var els = document.getElementsByName(identifier);
            if (op == 0) {
                for (let i = 0; i < els.length; i++) {
                    const element = els[i];
                    element.classList.add(className);
                }
            }
            else {
                for (let i = 0; i < els.length; i++) {
                    const element = els[i];
                    element.classList.remove(className);
                }
            }
            break;
        case 2:
            if (op == 0)
                document.getElementsByClassName(identifier).classList.add(className);
            else
                document.getElementsByClassName(identifier).classList.remove(className);
            break;
        case 3:
            if (op == 0)
                document.getElementsByTagName(identifer).classList.add(className);
            else
                document.getElementsByTagName(identifier).classList.remove(className);
            break;
        default:
            if (op == 0)
                document.getElementById(identifier).classList.add(className);
            else
                document.getElementById(identifier).classList.remove(className);
    }

    consoleLog('class:${className} operation:{op} kind:${kind}', showLog);
}

export function modClassesBy(op, kind, identifier, classNames, showLog) {
    switch (kind) {
        case 1:
            var els = document.getElementsByName(identifier);
            if (op == 0) {
                for (let i = 0; i < els.length; i++) {
                    const element = els[i];
                    element.classList.add(...classNames);
                }
            }
            else {
                for (let i = 0; i < els.length; i++) {
                    const element = els[i];
                    element.classList.remove(...classNames);
                }
            }
            break;
        case 2:
            if (op == 0)
                document.getElementsByClassName(identifier).classList.add(...classNames);
            else
                document.getElementsByClassName(identifier).classList.remove(...classNames);
            break;
        case 3:
            if (op == 0)
                document.getElementsByTagName(identifer).classList.add(...classNames);
            else
                document.getElementsByTagName(identifier).classList.remove(...classNames);
            break;
        default:
            if (op == 0)
                document.getElementById(identifier).classList.add(...classNames);
            else
                document.getElementById(identifier).classList.remove(...classNames);
    }

    consoleLog('class:${classNames} operation:${op} kind:${kind}', showLog);
}

export function modAttributeBy(op, kind, identifier, name, value, showLog) {
    switch (kind) {
        case 1:
            if (op == 0) {
                var els = document.getElementsByName(identifier);
                for (let i = 0; i < els.length; i++) {
                    const element = els[i];
                    // Set the attribute
                    element.setAttribute(name, value);
                }
            }
            else {
                var els = document.getElementByName(identifier);
                for (let i = 0; i < els.length; i++) {
                    const element = els[i];
                    element.removeAttribute(name);
                }
            }
            break;
        case 2:
            if (op == 0)
                document.getElementsByClassName(identifier).setAttribute(name, value);
            else
                document.getElementsByClassName(identifier).removeAttribute(name);
            break;
        case 3:
            if (op == 0)
                document.getElementsByTagName(identifier).setAttribute(name, value);
            else
                document.getElementsByTagName(identifier).removeAttribute(name);
            break;
        default:
            if (op == 0)
                document.getElementById(identifier).setAttribute(name, value);
            else
                document.getElementById(identifier).removeAttribute(name);
    }

    consoleLog('attribute ${name} added to ${identifier}');
}

// body

export function addClassToBody(className, showLog) {
    document.body.classList.add(className);
    consoleLog('class ${className} added to body', showLog);
}
export function addClassesToBody(classNames, showLog) {
    document.body.classList.add(...classNames);
    consoleLog('class ${classNames} added to body', showLog);
}

export function remClassFromBody(className, showLog) {
    document.body.classList.remove(className);
    consoleLog('class ${className} added to body', showLog);
}
export function remClassesFromBody(classNames, showLog) {
    document.body.classList.remove(...classNames);
    consoleLog('class ${classNames} added to body', showLog);
}