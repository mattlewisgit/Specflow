import { FooterBarService } from "../services/footer-bar.service";

var instance : FooterBarService = null ;

export function footerBarServiceFactory() {
    if (instance == null) {
        instance = new FooterBarService();
    }

    return instance;
}
