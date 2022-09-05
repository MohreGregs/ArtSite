import { Rating } from "../enums/rating";
import { ArtistModel } from "./artistModel";
import { BaseModel } from "./baseModel";
import { CharacterModel } from "./characterModel";

export interface ArtworkModel extends BaseModel {
    description: string;
    file: string;
    extension: string;
    rating: Rating;
    artists: ArtistModel[];
    characters: CharacterModel[];
}
