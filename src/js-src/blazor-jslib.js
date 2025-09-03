
// console.log
export function fg0(msg) {
    if (msg == null || msg.match(/^ *$/) !== null) {
        return;
    }

    console.log(msg);
}


/** HTML DOCUMENT */
export function fd0(op, name, value, log) {
    var doc = document.documentElement;
    if (op == 0)
        doc.setAttribute(name, value);
    else
        doc.removeAttribute(name);

    fg0(log);
}

export function fd1(url, appendTo, isAsync, log) {
    const script = document.createElement('script');
    script.type = 'text/javascript';
    script.src = url;
    script.async = isAsync;

    if (appendTo == 0) {
        document.head.appendChild(script);
    } else {
        document.body.appendChild(script);
    }

    fg0(log);
}

export function fd2(url, appendTo, log) {
    const link = document.createElement('link');
    link.rel = 'stylesheet';
    link.href = url;

    if (appendTo == 0) {
        document.head.appendChild(link);
    } else {
        document.body.appendChild(link);
    }

    fg0(log);
}

/** HEAD */

export function fh0(name, content, log) {
    const meta = document.createElement('meta');
    meta.name = name;

    if (content != null)
        meta.content = content;

    document.head.appendChild(meta);

    fg0(log);
}

/** BODY */

export function fb0(className, log) {
    document.body.classList.add(className);
    fg0(log);
}
export function fb1(classNames, log) {
    document.body.classList.add(...classNames);
    fg0(log);
}
export function fb2(className, log) {
    document.body.classList.remove(className);
    fg0(log);
}
export function fb3(classNames, log) {
    document.body.classList.remove(...classNames);
    fg0(log);
}
export function fb4(op, name, value, log) {
    var el = document.body;
    if (op == 0)
        el.setAttribute(name, value);
    else
        el.removeAttribute(name);
    fg0(log);
}

/** ELEMENTS */
export function fe0(op, kind, identifier, className, log) {
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
    fg0(log);
}

export function fe1(op, kind, identifier, classNames, log) {
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
    fg0(log);
}

export function fe2(op, kind, identifier, name, value, log) {
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
    fg0(log);
}

export function fe3(op, kind, identifier, contentType, content, log) {
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
    fg0(log);
}

export function fe4(kind, identifier, log) {
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
    fg0(log);
}

export function fe5(kind, identifier, value, log) {
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
    fg0(log);
}

