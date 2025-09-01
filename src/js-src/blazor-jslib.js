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
            for (let i = 0; i < els.length; i++) {
                const element = els[i];
                if (op == 0)
                    element.classList.add(className);
                else
                    element.classList.remove(className);
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
            for (let i = 0; i < els.length; i++) {
                const element = els[i];
                if (op == 0)
                    element.classList.add(...classNames);
                else
                    element.classList.remove(...classNames);
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
            var els = document.getElementsByName(identifier);
            for (let i = 0; i < els.length; i++) {
                const element = els[i];
                if (op == 0)
                    element.setAttribute(name, value);
                else
                    element.removeAttribute(name);
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

    consoleLog('attribute ${name} added to ${identifier}', showLog);
}

export function elementAddContent(op, kind, identifier, contentType, content, showLog) {
    switch (kind) {
        case 1:
            var els = document.getElementsByName(identifier);
            for (let i = 0; i < els.length; i++) {
                const element = els[i];
                if (contentType == 0)
                    element.textContent = op == 0 ? content : '';
                else
                    element.innerHTML = op == 0 ? content : '';
            }
            break;
        case 2:
            var el = document.getElementsByClassName(identifier);
            if (contentType == 0)
                el.textContent = op == 0 ? content : '';
            else
                el.innerHTML = op == 0 ? content : '';
            break;
        case 3:
            var el = document.getElementsByTagName(identifier);
            if (contentType == 0)
                el.textContent = op == 0 ? content : '';
            else
                el.innerHTML = op == 0 ? content : '';
            break;
        default:
            var el = document.getElementById(identifier);
            if (contentType == 0)
                el.textContent = op == 0 ? content : '';
            else
                el.innerHTML = op == 0 ? content : '';
    }

    consoleLog('content added', showLog);
}

export function elementGetValue(kind, identifier) {
    switch (kind) {
        case 1:
            return document.getElementsByName(identifier)[0].value;
        case 2:
            return document.getElementsByClassName(identifier).value;
        case 3:
            return document.getElementsByTagName(identifer).value;
        default:
            return document.getElementById(identifier).value;
    }
}

export function elementSetValue(kind, identifier, value) {
    switch (kind) {
        case 1:
            document.getElementsByName(identifier)[0].value = value;
            break;
        case 2:
            document.getElementsByClassName(identifier).value = value;
            break;
        case 3:
            document.getElementsByTagName(identifer).value = value;
            break;
        default:
            document.getElementById(identifier).value = value;
    }
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