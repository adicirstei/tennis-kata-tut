module Kata.TennisProperties

open FsCheck
open FsCheck.Xunit
open Swensen.Unquote


open Kata.Tennis

[<Property>]
let ``Given deuce when player wins then score is correct``
  (winner : Player) =
  let actual = scoreWhenDeuce winner
  let expected = Advantage winner

  actual =! expected

[<Property>]
let ``Given player when player has advantage then score should be correct``
  ( winner : Player ) =
  let actual = scoreWhenAdvantage winner winner
  let expected = Game winner
  actual =! expected


[<Property>]
let ``Given player when other player has advantage then score should be correct``
  ( player : Player ) =
  let actual = scoreWhenAdvantage player (other player)
  let expected = Deuce
  actual =! expected


[<Property>]
let ``Given player: 40 when player wins then score is correct``
  (current : FortyData ) =
  let actual = scoreWhenForty current current.Player

  let expected = Game current.Player

  actual =! expected