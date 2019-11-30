export interface IBill{
    INDEX :number;
    PRODUCTID : String;
    PRODUCTNAME : String;
    PRODUCTNUMBER : number;
    PRODUCTPRICE : number;
    TOTAL : number;
}
export class BillModel implements IBill{
    INDEX :number;
    PRODUCTID : String;
    PRODUCTNAME : String;
    PRODUCTNUMBER : number;
    PRODUCTPRICE : number;
    TOTAL : number;
}