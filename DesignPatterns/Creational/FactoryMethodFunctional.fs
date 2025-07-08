module DesignPatterns.Creational.FactoryMethodFunctional

open DesignPatterns.Creational.FactoryMethodTypes

let createDelivery (deliveryType: DeliveryType) (config: DeliveryConfig): string =
    $"Deliver by {deliveryType} ({config.fuel}L gas remaining)"

let createLandDelivery = createDelivery DeliveryType.Truck
let createSeaDelivery = createDelivery DeliveryType.Ship

let runScenario () =
    printfn "----------- FACTORY METHOD (FUNCTIONAL) --------------"
    printfn $"%s{createLandDelivery { fuel = 102 }}"
    printfn $"%s{createSeaDelivery { fuel = 1024 }}"