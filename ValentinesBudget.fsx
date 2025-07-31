// Define Cuisine 
type Cuisine =
    | Korean
    | Turkish

// Define MovieType 
type MovieType =
    | Regular
    | IMAX
    | DBOX
    | RegularWithSnacks
    | IMAXWithSnacks
    | DBOXWithSnacks

// Define Activity 
type Activity =
    | BoardGame
    | Chill
    | Movie of MovieType
    | Restaurant of Cuisine
    | LongDrive of kilometres:int * fuelPricePerKm:float

// Define budget calculation function
let calculateBudget activity =
    match activity with
    | BoardGame | Chill -> 0.0
    | Movie mt ->
        match mt with
        | Regular -> 12.0
        | IMAX -> 17.0
        | DBOX -> 20.0
        | RegularWithSnacks -> 12.0 + 5.0
        | IMAXWithSnacks -> 17.0 + 5.0
        | DBOXWithSnacks -> 20.0 + 5.0
    | Restaurant cuisine ->
        match cuisine with
        | Korean -> 70.0
        | Turkish -> 65.0
    | LongDrive (km, rate) ->
        float km * rate

// Sample activities
let sampleActivities = [
    BoardGame
    Chill
    Movie Regular
    Movie IMAXWithSnacks
    Restaurant Korean
    LongDrive (120, 0.15)
]

// Calculate budgets
let individualBudgets =
    sampleActivities
    |> List.map (fun act -> act, calculateBudget act)

// Print individual budgets
printfn "\nSample budgets:"
individualBudgets
|> List.iter (fun (act, price) ->
    printfn "- %-20A → CAD %.2f" act price)

// Calculate and print total budget
let totalBudget =
    individualBudgets
    |> List.sumBy snd

printfn "\nTotal Valentine's Day budget: CAD %.2f" totalBudget
