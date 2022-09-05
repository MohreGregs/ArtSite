import { BaseModel } from "./baseModel";
import { BaseNameModel } from "./baseNameModel";
import { SongModel } from "./songModel";

export interface InterestsModel extends BaseModel {
    hobbies: BaseNameModel[];
    music: SongModel[];
}
