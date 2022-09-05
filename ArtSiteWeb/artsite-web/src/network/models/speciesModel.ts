import { BaseNameModel } from "./baseNameModel";
import { CharacterModel } from "./characterModel";

export interface SpeciesModel extends BaseNameModel {
    character: CharacterModel;
}
