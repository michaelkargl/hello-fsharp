module DesignPatterns.Creational.FactoryMethodTypes

open DesignPatterns.UnitTypes

type ITransporter =
    abstract member Deliver: unit -> string
    
type DeliveryType =
    | Truck
    | Ship

type DeliveryConfig = {
    fuel: Liter
}

type Truck(fuelLiter: int) =
    interface ITransporter with
        member this.Deliver() =
            $"Deliver by Truck ({fuelLiter}L gas remaining)"

type Ship(fuelLiter: int) =
    interface ITransporter with
        member this.Deliver() =
            $"Deliver by Ship ({fuelLiter}L fuel remaining)"
