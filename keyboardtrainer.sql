CREATE DATABASE keyboardtrainer;
USE keyboardtrainer;

create table english_word (id INTEGER PRIMARY KEY AUTO_INCREMENT, word TEXT);
create table english_text (id INTEGER PRIMARY KEY AUTO_INCREMENT, text TEXT);
create table english_song (id INTEGER PRIMARY KEY AUTO_INCREMENT, song TEXT);
create table russian_song (id INTEGER PRIMARY KEY AUTO_INCREMENT, song TEXT);
create table russian_word (id INTEGER PRIMARY KEY AUTO_INCREMENT, word TEXT);
create table russian_text (id INTEGER PRIMARY KEY AUTO_INCREMENT, text TEXT);