import { Gender } from "src/network/enums/gender";
import { Sexuality } from "src/network/enums/sexuality";

export class SearchObject{
  public nameString?: string;
  public tags?: Map<number, boolean>;
  public minAge?: number;
  public maxAge?: number;
  public species?: number;
  public gender?: Gender;
  public sexuality?: Sexuality;

  constructor(){}
}
