module DesignPatterns.Creational.FactoryMethodOop

// https://refactoring.guru/design-patterns/factory-method

type ITransporter =
    abstract member Deliver: unit -> string

type Truck(fuelLiter: int) =
    interface ITransporter with
        member this.Deliver() =
            $"Deliver by Truck ({fuelLiter}L gas remaining)"

type Ship(fuelLiter: int) =
    interface ITransporter with
        member this.Deliver() =
            $"Deliver by Ship ({fuelLiter}L fuel remaining)"

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
    printfn "----------------FACTORY METHOD----------------------"

    let landTransporter: ITransporter =
        LandLogisticsFactory().AddFuel(100).CreateTransporter()
    let seaTransporter: ITransporter =
        SeaLogisticsFactory().AddFuel(2025).CreateTransporter()
    
    printfn $"Land Transport: %s{landTransporter.Deliver()}"
    printfn $"Sea Transport: %s{seaTransporter.Deliver()}"
