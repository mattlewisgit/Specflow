﻿// jscs:disable maximumLineLength
var mockData = {
    chapters: [{
        Id: 1,
        Name: "ABDOMEN (EXCL. URINARY &amp; REPRODUCTIVE ORGANS)",
        Sections: [{
            Id: 1,
            Name: "Abdominal wall",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 2,
            Name: "Other Organs (Mainly Digestive)",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 3,
            Name: "Duodenum",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 4,
            Name: "Jejunum/Ileum",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 5,
            Name: "Large Intestine",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 6,
            Name: "Major Vessels",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 7,
            Name: "Oesophagus",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 8,
            Name: "Peritoneum",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 9,
            Name: "Rectum/Anus",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 10,
            Name: "Stomach",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }]
    }, {
        Id: 2,
        Name: "BONES, JOINTS &amp; CONNECTIVE TISSUE / TENDON MUSCLE",
        Sections: [{
            Id: 1,
            Name: "Amputation",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 2,
            Name: "Bone (Non-Specific)",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 3,
            Name: "Connective tissue / Tendon Muscle",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 4,
            Name: "External fixation / traction",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 5,
            Name: "Elbow",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 6,
            Name: "Foot",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 7,
            Name: "Fractures",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 8,
            Name: "Hand",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 9,
            Name: "Hip, Leg and Pelvis",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 10,
            Name: "Joints, including relacement / reconstruction (not listed elsewhere)",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 11,
            Name: "Knee",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 12,
            Name: "Nerves",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 13,
            Name: "Shoulder",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }]
    }, {
        Id: 3,
        Name: "BRAIN, CRANIUM AND OTHER INTRACRANIAL ORGANS",
        Sections: [{
            Id: 1,
            Name: "Brain",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 2,
            Name: "Cranium",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 3,
            Name: "Meninges",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 4,
            Name: "Nerves",
            Procedures: []
        }, {
            Id: 5,
            Name: "Other",
            Procedures: []
        }, {
            Id: 6,
            Name: "Vessels",
            Procedures: []
        }]
    }, {
        Id: 4,
        Name: "BREAST",
        Sections: [{
            Id: 1,
            Name: "Other",
            Procedures: []
        }, {
            Id: 2,
            Name: "Excision/Biopsy codes",
            Procedures: []
        }, {
            Id: 3,
            Name: "Mastectomy",
            Procedures: []
        }, {
            Id: 4,
            Name: "Reconstruction of breast",
            Procedures: []
        }]
    }, {
        Id: 5,
        Name: "CHEMOTHERAPY",
        Sections: [{
            Id: 1,
            Name: "Chemotherapy",
            Procedures: []
        }]
    }, {
        Id: 6,
        Name: "EAR, NOSE &amp; THROAT",
        Sections: [{
            Id: 1,
            Name: "External Ear",
            Procedures: []
        }, {
            Id: 2,
            Name: "Fibreoptic Endoscopic Procedures (GA or LA)",
            Procedures: []
        }, {
            Id: 3,
            Name: "Inner Ear",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 4,
            Name: "Larynx And Trachea",
            Procedures: []
        }, {
            Id: 5,
            Name: "Middle Ear and Mastoid",
            Procedures: []
        }, {
            Id: 6,
            Name: "Nasal Sinuses",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 7,
            Name: "Nose and Nasal Cavity",
            Procedures: []
        }, {
            Id: 8,
            Name: "Throat",
            Procedures: []
        }]
    }, {
        Id: 7,
        Name: "ENDOSCOPIC GIT Procedures",
        Sections: [{
            Id: 1,
            Name: "Endoscopic GIT Procedures",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }]
    }, {
        Id: 8,
        Name: "EYE &amp; ORBITAL CONTENTS",
        Sections: [{
            Id: 1,
            Name: "Conjunctiva",
            Procedures: []
        }, {
            Id: 2,
            Name: "Cornea",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 3,
            Name: "Eyebrow &amp; Lid",
            Procedures: []
        }, {
            Id: 4,
            Name: "General",
            Procedures: []
        }, {
            Id: 5,
            Name: "Globe &amp; Orbit",
            Procedures: []
        }, {
            Id: 6,
            Name: "Iris &amp; Anteria Chamber",
            Procedures: []
        }, {
            Id: 7,
            Name: "Lacrimal System",
            Procedures: [{
                Code: "G1900",
                Description: "Rigid oesophagoscopy (including biopsy, laser or diathermy destruction of lesions)",
                OperatorFee: 270,
                AnaesthetistFee: 170
            }, {
                Code: "G4410",
                Description: "Oesophageal physiology studies (including pH measurement)",
                OperatorFee: 156,
                AnaesthetistFee: 140
            }, {
                Code: "G1901",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with insertion of prosthesis",
                OperatorFee: 312,
                AnaesthetistFee: 170
            }, {
                Code: "G4430",
                Description: "Therapeutic oesophago-gastro-duodenoscopy (OGD) with dilatation",
                OperatorFee: 183,
                AnaesthetistFee: 170
            }, {
                Code: "G4440",
                Description: "Therapeutic Oesophago-gastro-duodenoscopy (OGD) with insertion percutaneous endoscopic gastrostomy/percutaneous endoscopic jejunostomy",
                OperatorFee: 228,
                AnaesthetistFee: 170
            }, {
                Code: "G4442",
                Description: "GASTROSCOPIC BALLOON INSERTION",
                OperatorFee: 312,
                AnaesthetistFee: 160
            }, {
                Code: "G4443",
                Description: "Gastroscopic Balloon Removal",
                OperatorFee: 146,
                AnaesthetistFee: 120
            }, {
                Code: "G4520",
                Description: "Diagnostic enteroscopy",
                OperatorFee: 146,
                AnaesthetistFee: 140
            }, {
                Code: "G4530",
                Description: "Catheterless oesophageal ph monitoring (e.g. bravo)",
                OperatorFee: 183,
                AnaesthetistFee: null
            }]
        }, {
            Id: 8,
            Name: "Lens",
            Procedures: []
        }, {
            Id: 9,
            Name: "Muscles",
            Procedures: []
        }, {
            Id: 10,
            Name: "Retina",
            Procedures: []
        }, {
            Id: 11,
            Name: "Sclera",
            Procedures: []
        }, {
            Id: 12,
            Name: "Vitreous",
            Procedures: []
        }]
    }, {
        Id: 9,
        Name: " FACE, MOUTH, SALIVARY &amp; THYROID",
        Sections: [{
            Id: 1,
            Name: "Face and Jaws",
            Procedures: []
        }, {
            Id: 2,
            Name: "Lips",
            Procedures: []
        }, {
            Id: 3,
            Name: "Mouth Cavity",
            Procedures: []
        }, {
            Id: 4,
            Name: "Neck",
            Procedures: []
        }, {
            Id: 5,
            Name: "Palate",
            Procedures: []
        }, {
            Id: 6,
            Name: "Salivary Glands",
            Procedures: []
        }, {
            Id: 7,
            Name: "Teeth",
            Procedures: []
        }, {
            Id: 8,
            Name: "Thyroid and Parathyroid Glands",
            Procedures: []
        }, {
            Id: 9,
            Name: "Tongue",
            Procedures: []
        }]
    }, {
        Id: 10,
        Name: "FEMALE REPRODUCTIVE ORGANS",
        Sections: [{
            Id: 1,
            Name: "Cervix Uteri",
            Procedures: []
        }, {
            Id: 2,
            Name: "Suspension",
            Procedures: []
        }, {
            Id: 3,
            Name: "Uterus / Adnexa",
            Procedures: []
        }, {
            Id: 4,
            Name: "Vagina / Perineum",
            Procedures: []
        }, {
            Id: 5,
            Name: "Vulva / Labia",
            Procedures: []
        }]
    }, {
        Id: 11,
        Name: "HAEMATOLOGY",
        Sections: [{
            Id: 1,
            Name: "Haematology",
            Procedures: []
        }]
    }, {
        Id: 12,
        Name: "INTERVENTIONAL RADIOLOGY",
        Sections: [{
            Id: 1,
            Name: "Angioplasty",
            Procedures: []
        }, {
            Id: 2,
            Name: "Biopsy",
            Procedures: []
        }, {
            Id: 3,
            Name: "Dilatation",
            Procedures: []
        }, {
            Id: 4,
            Name: "Drainage",
            Procedures: []
        }, {
            Id: 5,
            Name: "Embolisation",
            Procedures: []
        }, {
            Id: 6,
            Name: "Gastrointestinal",
            Procedures: []
        }, {
            Id: 7,
            Name: "Head and Neck",
            Procedures: []
        }, {
            Id: 8,
            Name: "Liver",
            Procedures: []
        }, {
            Id: 9,
            Name: "Thrombolysis",
            Procedures: []
        }, {
            Id: 10,
            Name: "Other",
            Procedures: []
        }, {
            Id: 11,
            Name: "Thorax",
            Procedures: []
        }, {
            Id: 12,
            Name: "Spine",
            Procedures: []
        }, {
            Id: 13,
            Name: "Urinary",
            Procedures: []
        }]
    }, {
        Id: 13,
        Name: " INVESTIGATIONS, SIMPLE Procedures AND CONSULTATION IdS",
        Sections: [{
            Id: 1,
            Name: "Consultation Ids",
            Procedures: []
        }, {
            Id: 2,
            Name: "Investigations",
            Procedures: []
        }, {
            Id: 3,
            Name: "Simple Procedures",
            Procedures: []
        }]
    }, {
        Id: 14,
        Name: " PREGNANCY &amp; CONFINEMENT",
        Sections: [{
            Id: 1,
            Name: "Pregnancy &amp; Confinement",
            Procedures: []
        }]
    }, {
        Id: 15,
        Name: "SKIN &amp; SUBCUTANEOUS TISSUE",
        Sections: [{
            Id: 1,
            Name: "Burns, Scars &amp; Contractures",
            Procedures: []
        }, {
            Id: 2,
            Name: "Flaps &amp; Free Skin Grafts",
            Procedures: []
        }, {
            Id: 3,
            Name: "Lesions of skin",
            Procedures: []
        }, {
            Id: 4,
            Name: "Repair",
            Procedures: []
        }]
    }, {
        Id: 16,
        Name: " SPINE, SPINAL CORD AND PERIPHERAL NERVES",
        Sections: [{
            Id: 1,
            Name: "Other Nerve Blocks",
            Procedures: []
        }, {
            Id: 2,
            Name: "Neurophysiological Procedures",
            Procedures: []
        }, {
            Id: 3,
            Name: "Other Procedures",
            Procedures: []
        }, {
            Id: 4,
            Name: "Paraspinal Injections",
            Procedures: []
        }, {
            Id: 5,
            Name: "Peripheral Nerves",
            Procedures: []
        }, {
            Id: 6,
            Name: "Nerve Roots",
            Procedures: []
        }, {
            Id: 7,
            Name: "Spinal Cord",
            Procedures: []
        }, {
            Id: 8,
            Name: "Spinal Column (including Intervertebral Disc)",
            Procedures: []
        }, {
            Id: 9,
            Name: "Sympathetic Nerves",
            Procedures: []
        }]
    }, {
        Id: 17,
        Name: " THORAX &amp; INTRA-THORACIC ORGANS",
        Sections: [{
            Id: 1,
            Name: "Bronchi / Lungs / Pleura",
            Procedures: []
        }, {
            Id: 2,
            Name: "Heart - Cardiology",
            Procedures: []
        }, {
            Id: 3,
            Name: "Chest Wall",
            Procedures: []
        }, {
            Id: 4,
            Name: "Fibreoptic Endoscopic Procedures (GA or LA)",
            Procedures: []
        }, {
            Id: 5,
            Name: "Great Vessels",
            Procedures: []
        }, {
            Id: 6,
            Name: "Heart - Cardiac Surgery",
            Procedures: []
        }, {
            Id: 7,
            Name: "Mediastinum",
            Procedures: []
        }, {
            Id: 8,
            Name: "Oesophagus",
            Procedures: []
        }, {
            Id: 9,
            Name: "Other",
            Procedures: []
        }, {
            Id: 10,
            Name: "Trachea",
            Procedures: []
        }, {
            Id: 11,
            Name: "Video Assisted Thoracic Surgery (VATS)",
            Procedures: []
        }]
    }, {
        Id: 18,
        Name: " URINARY SYSTEM AND MALE REPRODUCTIVE ORGANS",
        Sections: [{
            Id: 1,
            Name: "Bladder",
            Procedures: []
        }, {
            Id: 2,
            Name: "Kidney / Renal Pelvic",
            Procedures: []
        }, {
            Id: 3,
            Name: "Genitalia",
            Procedures: []
        }, {
            Id: 4,
            Name: "Prostate",
            Procedures: []
        }, {
            Id: 5,
            Name: "Ureter",
            Procedures: []
        }, {
            Id: 6,
            Name: "Urethra",
            Procedures: []
        }]
    }, {
        Id: 19,
        Name: " VASCULAR SYSTEM",
        Sections: [{
            Id: 1,
            Name: "Abdominal Vessels",
            Procedures: []
        }, {
            Id: 2,
            Name: "Head &amp; Neck",
            Procedures: []
        }, {
            Id: 3,
            Name: "Ileo-Femoral Vessels",
            Procedures: []
        }, {
            Id: 4,
            Name: "Lymphatic System",
            Procedures: []
        }, {
            Id: 5,
            Name: "Non-Specific",
            Procedures: []
        }, {
            Id: 6,
            Name: "Renal",
            Procedures: []
        }, {
            Id: 7,
            Name: "Thoracic",
            Procedures: []
        }, {
            Id: 8,
            Name: "Varicose Veins",
            Procedures: []
        }]
    }]
};
angular
    .module("FeemaximaService", [])
    .service("FeemaximaService", function () {
        "use strict";

        // Typehead currently doesn't return dataset name on select. 
        this.datasetTypes =
        {
            Chapter: "Chapter",
            Section: "Section",
            Procedure: "Procedure"
        }

        this.datasets = {
            chapters: [],
            sections: [],
            procedures: []
        };

        this.subArrayPropertyNames =
        {
            Procedures: "Procedures",
            Sections: "Sections"
        }

        this.getChapters = function () {
            return _.sortBy(mockData.chapters);
        };

        this.populateDatasets = function () {
            var datasetTypes = this.datasetTypes;
            this.datasets.chapters = _.uniq(_.map(mockData.chapters,
                function (chapter) {
                    return { Id: chapter.Id, Value: chapter.Name, Type: datasetTypes.Chapter };
                }));
            var sections = _.flatten(_.pluck(mockData.chapters, this.subArrayPropertyNames.Sections));
            this.datasets.sections = _.uniq(_.map(sections,
                function (section) {
                    return { Id: section.Id, Value: section.Name, Type: datasetTypes.Section };
                }));
            this.datasets.procedures = _.uniq(_.map(_.flatten(_.pluck(sections, this.subArrayPropertyNames.Procedures)),
                function (procedure) {
                    return { Code: procedure.Code, Value: procedure.Description, Type: datasetTypes.Procedure };
                }), false, function (item) {
                    return item.Code;
                });
        };

        this.searchDatasets = function (sourceName, key, text) {
            if (this.datasets.chapters.length === 0) {
                this.populateDatasets();
            };
            text = (text || "").toLowerCase();

            return _.sortBy(this.datasets[sourceName].filter(function (item) {
                return item[key].toLowerCase().indexOf(text) > -1;
            }), key);
        };
    });
