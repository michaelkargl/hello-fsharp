module DesignPatterns.Creational.FactoryMethodOop

open DesignPatterns.Creational.FactoryMethodTypes

// https://refactoring.guru/design-patterns/factory-method

[<AbstractClass>]
type LogisticsFactory() =
    member val FuelInLiter = 0 with get, set

    abstract member CreateTransporter: unit -> ITransporter

    member this.AddFuel(liters: int) : LogisticsFactory =
        this.FuelInLiter <- liters
        this

type LandLogisticsFactory() =
    inherit LogisticsFactory()
    override this.CreateTransporter() = Truck(this.FuelInLiter)

type SeaLogisticsFactory() =
    inherit LogisticsFactory()
    override this.CreateTransporter() = Ship(this.FuelInLiter) 

let runScenario () =
    printfn "----------- FACTORY METHOD (OOP) --------------"

    let landTransporter: ITransporter =
        LandLogisticsFactory().AddFuel(100).CreateTransporter()
    let seaTransporter: ITransporter =
        SeaLogisticsFactory().AddFuel(2025).CreateTransporter()
    
    printfn $"Land Transport: %s{landTransporter.Deliver()}"
    printfn $"Sea Transport: %s{seaTransporter.Deliver()}"
