using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class Ashamon : MonoBehaviour {
	public int curr_health;
	public int curr_mana;
	public int level = 1;
	
	//Type, names
	public Dictionary<string, bool> curr_type_array;
	public string ashamon_name;
	public string nickname;
	
	//Stats
	public int[] curr_stat_array = new int[] {0, 0, 0, 0, 0, 0, 0};
	
	public int[] custom_iv_ev_dr = new int[] {0, 0, 0, 0, 0, 0, 0};
	
	public int[] base_stat_gain;
	
	//Move info
	public Dictionary<string, int> move_dictionary;
	public int current_moveset = 1;
	public string[] move_set1 = new string[4] {"", "", "", ""};
	public string[] move_set2 = new string[4] {"", "", "", ""};
	public List<string> all_learned_moves_list;
	
	public Dictionary<string, int> evolution_table;
	public string sprite_table;
	public string special_equip; //Hm equivalent
	public float base_catch_rate;
	
	//Booleans
	public bool is_wild;
	public bool is_owned;
	public bool is_fainted;
	
	//Instantiation
	public Ashamon()
	{
	}
	
	public Ashamon(Ashamon other, int other_level, bool wild, bool owned)
	{
		curr_type_array = other.curr_type_array;
		ashamon_name = other.ashamon_name;
		nickname = "";
		level = other_level;
		base_stat_gain = other.base_stat_gain;
		//Create current stats
		initialize_current_stats();
		
		move_dictionary = other.move_dictionary;
		initialize_all_learned_moves();
		initialize_moveset1();
		evolution_table = other.evolution_table;
		sprite_table = other.sprite_table;
		special_equip = other.special_equip;
		base_catch_rate = other.base_catch_rate;
		
		is_fainted = false;
	}
	
	//Methods
	public void initialize_current_stats()
	{
		for (var i = 0; i < curr_stat_array.Length; i++)
		{
			curr_stat_array[i] = base_stat_gain[i] * level;
			if (i == 0){
				curr_health = base_stat_gain[0] * level;
			}
			if (i == 1){
				curr_mana = base_stat_gain[1] * level;
			}
		}
	}
	
	//Takes the move_dictionary and based on the level, initalizes the learned moves to everything at it's level and less.
	public void initialize_all_learned_moves()
	{
		foreach(var item in move_dictionary)
		{
			if (item.Value <= level)
			{
				all_learned_moves_list.Add(item.Key);
			}
		}
	}
	
	//Take the all_learned_moves dictionary and initializes moveset1 to random moves from it.
	public void initialize_moveset1()
	{
		if (all_learned_moves_list.Count <= 4)
		{
			for (var i = 0; i < all_learned_moves_list.Count; i++)
			{
				move_set1[i] = all_learned_moves_list[i];
			}
		}
		else
		{
			//The initial moveset1 needs to be initialized to non-repeating random moves.
			//This code takes the number of ints needed and returns a list of non-repeatings ints.
			System.Random r = new System.Random();
			List<int> intList = Enumerable.Range(0, all_learned_moves_list.Count).OrderBy(x => r.Next()).Take(4).ToList();
			for (var i = 0; i < intList.Count; i++)
			{
				move_set1[i] = all_learned_moves_list[intList[i]];
			}
		}
	}
	
	public void level_up()
	{
		level = level + 1;
		for (var i = 0; i < curr_stat_array.Length; i++)
		{
			curr_stat_array[i] = base_stat_gain[i] + curr_stat_array[i] + custom_iv_ev_dr[i];
		}
		foreach(var item in move_dictionary)
		{
			if (item.Value == level)
			{
				all_learned_moves_list.Add(item.Key);
			}
		}
	}
	
	public void evolve(Ashamon other)
	{
		ashamon_name = other.ashamon_name;
		base_stat_gain = other.base_stat_gain;
		move_dictionary = other.move_dictionary;
		evolution_table = other.evolution_table;
		sprite_table = other.sprite_table;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
