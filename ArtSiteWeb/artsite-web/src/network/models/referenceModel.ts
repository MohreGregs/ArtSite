import { ArtworkModel } from "./artworkModel";
import { BaseNameModel } from "./baseNameModel";

export interface ReferenceModel extends BaseNameModel {
    artwork: ArtworkModel;
}
