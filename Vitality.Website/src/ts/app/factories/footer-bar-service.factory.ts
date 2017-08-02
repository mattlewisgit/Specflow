import { FooterBarService } from "../services/footer-bar.service";

var instance= new FooterBarService();

export function footerBarServiceFactory() {
    return instance;
}
