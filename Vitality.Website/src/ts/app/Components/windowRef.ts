import { Injectable } from '@angular/core';

function _window(): any {
    // return the global native browser window object
    return window;
}

@Injectable()
export class WindowRef {
    get nativeWindow(): any {
        return _window();
    }

    ensureTrailingSlash(url:string) : string {
        var newUrl = url;
        while(newUrl.endsWith("/") || newUrl.indexOf("//") > -1)
        {
            newUrl = newUrl.replace("//", "/");
            newUrl = newUrl.split("/").slice(0, -1).join("/");
        }

        return newUrl + "/";
    }
}
