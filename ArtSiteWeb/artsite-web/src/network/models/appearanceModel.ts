import { BaseModel } from "./baseModel";
import { ColorModel } from "./colorModel";

export interface AppearanceModel extends BaseModel {
    appearanceInfo: string;
    designNotes: string;
    colors: ColorModel[];
}
