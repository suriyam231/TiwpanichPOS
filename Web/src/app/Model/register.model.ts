export interface IRegisterModel{
    STOREID : string;
    STORENAME : string;
    LOCATIONNUMBER : string;
    PROVINCE : string;
    DISTRICT : string;
    SUBDISTRICT : string;
    ZIPCODE : string;
    USERNAME :string;
    PASSWORD : string;
    STATUS : string;
}
export class RegisterModel implements IRegisterModel{
    STOREID : string;
    STORENAME : string;
    LOCATIONNUMBER : string;
    PROVINCE : string;
    DISTRICT : string;
    SUBDISTRICT : string;
    ZIPCODE : string;
    USERNAME :string;
    PASSWORD : string;
    STATUS : string; 
}