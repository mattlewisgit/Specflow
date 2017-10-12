export class Common {
    getParentElementByClass(key: string, element: HTMLElement): HTMLElement {
        while (element.className.indexOf(key) === -1) {
            element = element.parentElement;
        }
        return element;
    }

    getParentElementByTag(key: string, element: HTMLElement): HTMLElement {
        while (element.tagName !== key) {
            element = element.parentElement;
        }
        return element;
    }
}
