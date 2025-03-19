class Laptop {
    constructor(info, quality) {
        this.info = info;
        this.isOn = false;
        this.quality = quality;
    }

    turnOn() {
        if (!this.isOn) {
            this.isOn = true;
            this.quality--;
        }
        
    }

    turnOff() {
        if (this.isOn) {
            this.isOn = false;
            this.quality--;
        }
    }

    showInfo() {
        return JSON.stringify(this.info);
    }

    get price() {
        return Number(800 - this.info.age * 2 + this.quality * 0.5);
    }
}
