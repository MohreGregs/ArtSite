import { BaseNameModel } from "./baseNameModel";
import { CharacterModel } from "./characterModel";
import { ColorModel } from "./colorModel";

export interface TagModel extends BaseNameModel {
    color: ColorModel;
    characters: CharacterModel[];
}
