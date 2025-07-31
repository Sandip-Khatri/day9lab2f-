// Define record types
type Coach = { Name: string; FormerPlayer: bool }
type Stats = { Wins: int; Losses: int }
type Team = { Name: string; Coach: Coach; Stats: Stats }

// Create a list of 5 NBA teams
let teamList = [
    { Name = "San Antonio Spurs"
      Coach = { Name = "Gregg Popovich"; FormerPlayer = false }
      Stats = { Wins = 1390; Losses = 824 } }
    { Name = "Indiana Pacers"
      Coach = { Name = "Rick Carlisle"; FormerPlayer = false }
      Stats = { Wins = 993; Losses = 860 } }
    { Name = "Miami Heat"
      Coach = { Name = "Erik Spoelstra"; FormerPlayer = false }
      Stats = { Wins = 750; Losses = 609 } }
    { Name = "Los Angeles Lakers"
      Coach = { Name = "Mike Brown"; FormerPlayer = false }
      Stats = { Wins = 476; Losses = 320 } }
    { Name = "Chicago Bulls"
      Coach = { Name = "Billy Donovan"; FormerPlayer = false }
      Stats = { Wins = 195; Losses = 205 } }
]

// Filter successful teams: Wins > Losses
let successfulTeams =
    teamList
    |> List.filter (fun t -> t.Stats.Wins > t.Stats.Losses)

// Calculate success percentages
let successPercentages =
    teamList
    |> List.map (fun t ->
        let w = float t.Stats.Wins
        let l = float t.Stats.Losses
        let pct = if w + l > 0.0 then (w / (w + l) * 100.0) else 0.0
        t.Name, t.Coach.Name, pct)

// Display results
printfn "Successful NBA teams:"
successfulTeams
|> List.iter (fun t ->
    printfn "- %s (Coach: %s)" t.Name t.Coach.Name)

printfn "\nSuccess percentages:"
successPercentages
|> List.iter (fun (team, coach, pct) ->
    printfn "- %s (Coach: %s): %.1f%%" team coach pct)
