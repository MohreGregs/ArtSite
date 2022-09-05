import { BaseNameModel } from "./baseNameModel";

export interface ArtistModel extends BaseNameModel {
  website: string | null;
  furaffinity: string | null;
  toyHouse: string | null;
  twitter: string | null;
  artfight: string | null;
}
