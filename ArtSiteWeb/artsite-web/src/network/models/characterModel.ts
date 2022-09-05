import { Gender } from "../enums/gender";
import { Sexuality } from "../enums/sexuality";
import { AppearanceModel } from "./appearanceModel";
import { ArtistModel } from "./artistModel";
import { ArtworkModel } from "./artworkModel";
import { BaseNameModel } from "./baseNameModel";
import { GeneralInfoModel } from "./generalInfoModel";
import { InterestsModel } from "./interestsModel";
import { PersonalityModel } from "./personalityModel";
import { ReferenceModel } from "./referenceModel";
import { SpeciesModel } from "./speciesModel";
import { TagModel } from "./tagModel";

export interface CharacterModel extends BaseNameModel {
    age: number;
    gender: Gender;
    sexuality: Sexuality;
    iconId: number;
    icon: ArtworkModel;
    tags: TagModel[];
    species: SpeciesModel;
    originalDesigner: ArtistModel;
    references: ReferenceModel[];
    generalInfo: GeneralInfoModel;
    personality: PersonalityModel;
    interests: InterestsModel;
    appearance: AppearanceModel;
}
