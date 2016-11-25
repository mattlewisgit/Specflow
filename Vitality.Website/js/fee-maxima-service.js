// jscs:disable maximumLineLength
var mockData = {
    chapters: [{
        Code: "CHABD",
        Name: "ABDOMEN (EXCL. URINARY &amp; REPRODUCTIVE ORGANS)",
        Sections: [{
            Code: "SCAWA",
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
            Code: "SCDIG",
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
            Code: "SCDUO",
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
            Code: "SCJEJ",
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
            Code: "SCLAI",
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
            Code: "SCMVE",
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
            Code: "SCOSO",
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
            Code: "SCPER",
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
            Code: "SCRAN",
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
            Code: "SCSTO",
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
        Code: "CHBON",
        Name: "BONES, JOINTS &amp; CONNECTIVE TISSUE / TENDON MUSCLE",
        Sections: [{
            Code: "SCAMP",
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
            Code: "SCBNS",
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
            Code: "SCCTM",
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
            Code: "SCEFT",
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
            Code: "SCELB",
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
            Code: "SCFOO",
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
            Code: "SCFRA",
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
            Code: "SCHAN",
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
            Code: "SCHLP",
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
            Code: "SCJRR",
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
            Code: "SCKNE",
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
            Code: "SCNRV",
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
            Code: "SCSHO",
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
        Code: "CHBRA",
        Name: "BRAIN, CRANIUM AND OTHER INTRACRANIAL ORGANS",
        Sections: [{
            Code: "SCBRA",
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
            Code: "SCCRA",
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
            Code: "SCMEN",
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
            Code: "SCNER",
            Name: "Nerves",
            Procedures: []
        }, {
            Code: "SCOTH",
            Name: "Other",
            Procedures: []
        }, {
            Code: "SCVES",
            Name: "Vessels",
            Procedures: []
        }]
    }, {
        Code: "CHBRE",
        Name: "BREAST",
        Sections: [{
            Code: "SCBOT",
            Name: "Other",
            Procedures: []
        }, {
            Code: "SCEXC",
            Name: "Excision/Biopsy codes",
            Procedures: []
        }, {
            Code: "SCMAS",
            Name: "Mastectomy",
            Procedures: []
        }, {
            Code: "SCREC",
            Name: "Reconstruction of breast",
            Procedures: []
        }]
    }, {
        Code: "CHCHM",
        Name: "CHEMOTHERAPY",
        Sections: [{
            Code: "SCCHM",
            Name: "Chemotherapy",
            Procedures: []
        }]
    }, {
        Code: "CHEAR",
        Name: "EAR, NOSE &amp; THROAT",
        Sections: [{
            Code: "SCEXT",
            Name: "External Ear",
            Procedures: []
        }, {
            Code: "SCFEP",
            Name: "Fibreoptic Endoscopic Procedures (GA or LA)",
            Procedures: []
        }, {
            Code: "SCINN",
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
            Code: "SCLAR",
            Name: "Larynx And Trachea",
            Procedures: []
        }, {
            Code: "SCMID",
            Name: "Middle Ear and Mastoid",
            Procedures: []
        }, {
            Code: "SCNAS",
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
            Code: "SCNNC",
            Name: "Nose and Nasal Cavity",
            Procedures: []
        }, {
            Code: "SCTHR",
            Name: "Throat",
            Procedures: []
        }]
    }, {
        Code: "CHEND",
        Name: "ENDOSCOPIC GIT Procedures",
        Sections: [{
            Code: "SCEND",
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
        Code: "CHEYE",
        Name: "EYE &amp; ORBITAL CONTENTS",
        Sections: [{
            Code: "SCCON",
            Name: "Conjunctiva",
            Procedures: []
        }, {
            Code: "SCCOR",
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
            Code: "SCEBR",
            Name: "Eyebrow &amp; Lid",
            Procedures: []
        }, {
            Code: "SCEGN",
            Name: "General",
            Procedures: []
        }, {
            Code: "SCGLO",
            Name: "Globe &amp; Orbit",
            Procedures: []
        }, {
            Code: "SCIRI",
            Name: "Iris &amp; Anteria Chamber",
            Procedures: []
        }, {
            Code: "SCLAC",
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
            Code: "SCLEN",
            Name: "Lens",
            Procedures: []
        }, {
            Code: "SCMUS",
            Name: "Muscles",
            Procedures: []
        }, {
            Code: "SCRET",
            Name: "Retina",
            Procedures: []
        }, {
            Code: "SCSCL",
            Name: "Sclera",
            Procedures: []
        }, {
            Code: "SCVIT",
            Name: "Vitreous",
            Procedures: []
        }]
    }, {
        Code: "CHFAC",
        Name: " FACE, MOUTH, SALIVARY &amp; THYROID",
        Sections: [{
            Code: "SCFAC",
            Name: "Face and Jaws",
            Procedures: []
        }, {
            Code: "SCLIP",
            Name: "Lips",
            Procedures: []
        }, {
            Code: "SCMOU",
            Name: "Mouth Cavity",
            Procedures: []
        }, {
            Code: "SCNEC",
            Name: "Neck",
            Procedures: []
        }, {
            Code: "SCPAL",
            Name: "Palate",
            Procedures: []
        }, {
            Code: "SCSAL",
            Name: "Salivary Glands",
            Procedures: []
        }, {
            Code: "SCTEE",
            Name: "Teeth",
            Procedures: []
        }, {
            Code: "SCTHY",
            Name: "Thyroid and Parathyroid Glands",
            Procedures: []
        }, {
            Code: "SCTON",
            Name: "Tongue",
            Procedures: []
        }]
    }, {
        Code: "CHFEM",
        Name: "FEMALE REPRODUCTIVE ORGANS",
        Sections: [{
            Code: "SCCER",
            Name: "Cervix Uteri",
            Procedures: []
        }, {
            Code: "SCSUS",
            Name: "Suspension",
            Procedures: []
        }, {
            Code: "SCUTE",
            Name: "Uterus / Adnexa",
            Procedures: []
        }, {
            Code: "SCVAG",
            Name: "Vagina / Perineum",
            Procedures: []
        }, {
            Code: "SCVUL",
            Name: "Vulva / Labia",
            Procedures: []
        }]
    }, {
        Code: "CHHAE",
        Name: "HAEMATOLOGY",
        Sections: [{
            Code: "SCHAE",
            Name: "Haematology",
            Procedures: []
        }]
    }, {
        Code: "CHRAD",
        Name: "INTERVENTIONAL RADIOLOGY",
        Sections: [{
            Code: "SCANG",
            Name: "Angioplasty",
            Procedures: []
        }, {
            Code: "SCBIO",
            Name: "Biopsy",
            Procedures: []
        }, {
            Code: "SCDIL",
            Name: "Dilatation",
            Procedures: []
        }, {
            Code: "SCDRA",
            Name: "Drainage",
            Procedures: []
        }, {
            Code: "SCEMB",
            Name: "Embolisation",
            Procedures: []
        }, {
            Code: "SCGIL",
            Name: "Gastrointestinal",
            Procedures: []
        }, {
            Code: "SCHNK",
            Name: "Head and Neck",
            Procedures: []
        }, {
            Code: "SCLVR",
            Name: "Liver",
            Procedures: []
        }, {
            Code: "SCLYS",
            Name: "Thrombolysis",
            Procedures: []
        }, {
            Code: "SCOTR",
            Name: "Other",
            Procedures: []
        }, {
            Code: "SCRAX",
            Name: "Thorax",
            Procedures: []
        }, {
            Code: "SCSPE",
            Name: "Spine",
            Procedures: []
        }, {
            Code: "SCURY",
            Name: "Urinary",
            Procedures: []
        }]
    }, {
        Code: "CHINS",
        Name: " INVESTIGATIONS, SIMPLE Procedures AND CONSULTATION CODES",
        Sections: [{
            Code: "SCCOC",
            Name: "Consultation Codes",
            Procedures: []
        }, {
            Code: "SCINV",
            Name: "Investigations",
            Procedures: []
        }, {
            Code: "SCSIP",
            Name: "Simple Procedures",
            Procedures: []
        }]
    }, {
        Code: "CHPRE",
        Name: " PREGNANCY &amp; CONFINEMENT",
        Sections: [{
            Code: "SCPRE",
            Name: "Pregnancy &amp; Confinement",
            Procedures: []
        }]
    }, {
        Code: "CHSST",
        Name: "SKIN &amp; SUBCUTANEOUS TISSUE",
        Sections: [{
            Code: "SCBUR",
            Name: "Burns, Scars &amp; Contractures",
            Procedures: []
        }, {
            Code: "SCFFS",
            Name: "Flaps &amp; Free Skin Grafts",
            Procedures: []
        }, {
            Code: "SCLES",
            Name: "Lesions of skin",
            Procedures: []
        }, {
            Code: "SCREP",
            Name: "Repair",
            Procedures: []
        }]
    }, {
        Code: "CHSPI",
        Name: " SPINE, SPINAL CORD AND PERIPHERAL NERVES",
        Sections: [{
            Code: "SCNBL",
            Name: "Other Nerve Blocks",
            Procedures: []
        }, {
            Code: "SCNEU",
            Name: "Neurophysiological Procedures",
            Procedures: []
        }, {
            Code: "SCOPR",
            Name: "Other Procedures",
            Procedures: []
        }, {
            Code: "SCPAR",
            Name: "Paraspinal Injections",
            Procedures: []
        }, {
            Code: "SCPNV",
            Name: "Peripheral Nerves",
            Procedures: []
        }, {
            Code: "SCROO",
            Name: "Nerve Roots",
            Procedures: []
        }, {
            Code: "SCSPC",
            Name: "Spinal Cord",
            Procedures: []
        }, {
            Code: "SCSPI",
            Name: "Spinal Column (including Intervertebral Disc)",
            Procedures: []
        }, {
            Code: "SCSYM",
            Name: "Sympathetic Nerves",
            Procedures: []
        }]
    }, {
        Code: "CHTHO",
        Name: " THORAX &amp; INTRA-THORACIC ORGANS",
        Sections: [{
            Code: "SCBRO",
            Name: "Bronchi / Lungs / Pleura",
            Procedures: []
        }, {
            Code: "SCCAR",
            Name: "Heart - Cardiology",
            Procedures: []
        }, {
            Code: "SCCHE",
            Name: "Chest Wall",
            Procedures: []
        }, {
            Code: "SCFIB",
            Name: "Fibreoptic Endoscopic Procedures (GA or LA)",
            Procedures: []
        }, {
            Code: "SCGRE",
            Name: "Great Vessels",
            Procedures: []
        }, {
            Code: "SCHEA",
            Name: "Heart - Cardiac Surgery",
            Procedures: []
        }, {
            Code: "SCMED",
            Name: "Mediastinum",
            Procedures: []
        }, {
            Code: "SCOES",
            Name: "Oesophagus",
            Procedures: []
        }, {
            Code: "SCTOT",
            Name: "Other",
            Procedures: []
        }, {
            Code: "SCTRA",
            Name: "Trachea",
            Procedures: []
        }, {
            Code: "SCVID",
            Name: "Video Assisted Thoracic Surgery (VATS)",
            Procedures: []
        }]
    }, {
        Code: "CHURI",
        Name: " URINARY SYSTEM AND MALE REPRODUCTIVE ORGANS",
        Sections: [{
            Code: "SCBLA",
            Name: "Bladder",
            Procedures: []
        }, {
            Code: "SCKID",
            Name: "Kidney / Renal Pelvic",
            Procedures: []
        }, {
            Code: "SCLIA",
            Name: "Genitalia",
            Procedures: []
        }, {
            Code: "SCPRO",
            Name: "Prostate",
            Procedures: []
        }, {
            Code: "SCURE",
            Name: "Ureter",
            Procedures: []
        }, {
            Code: "SCUTH",
            Name: "Urethra",
            Procedures: []
        }]
    }, {
        Code: "CHVAS",
        Name: " VASCULAR SYSTEM",
        Sections: [{
            Code: "SCABD",
            Name: "Abdominal Vessels",
            Procedures: []
        }, {
            Code: "SCHNE",
            Name: "Head &amp; Neck",
            Procedures: []
        }, {
            Code: "SCILE",
            Name: "Ileo-Femoral Vessels",
            Procedures: []
        }, {
            Code: "SCLYM",
            Name: "Lymphatic System",
            Procedures: []
        }, {
            Code: "SCNON",
            Name: "Non-Specific",
            Procedures: []
        }, {
            Code: "SCREN",
            Name: "Renal",
            Procedures: []
        }, {
            Code: "SCTHO",
            Name: "Thoracic",
            Procedures: []
        }, {
            Code: "SCVAR",
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
                    return { Code: chapter.Code, Value: chapter.Name, Type: datasetTypes.Chapter };
                }));
            var sections = _.flatten(_.pluck(mockData.chapters, this.subArrayPropertyNames.Sections));
            this.datasets.sections = _.uniq(_.map(sections,
                function (section) {
                    return { Code: section.Code, Value: section.Name, Type: datasetTypes.Section };
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
