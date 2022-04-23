#pragma once
#include<fstream>
#include<istream>
#include<iostream>
#include<string>
#include <nlohmann/json.hpp>

using json = nlohmann::json;
namespace PrintShift_Name {
	using nlohmann::json;

	inline json get_untyped(const json& j, const char* property) {
		if (j.find(property) != j.end()) {
			return j.at(property).get<json>();
		}
		return json();
	}

	inline json get_untyped(const json& j, std::string property) {
		return get_untyped(j, property.data());
	}

	class PrintShift {
	public:
		PrintShift() = default;
		virtual ~PrintShift() = default;

	private:
		int64_t print_shift_along_x;
		int64_t print_shift_along_y;
		int64_t ChargerColor;

	
	public:
		const int64_t& get_print_shift_along_x() const { return print_shift_along_x; }
		int64_t& get_mutable_print_shift_along_x() { return print_shift_along_x; }
		void set_print_shift_along_x(const int64_t& value) { this->print_shift_along_x = value; }

		const int64_t& get_print_shift_along_y() const { return print_shift_along_y; }
		int64_t& get_mutable_print_shift_along_y() { return print_shift_along_y; }
		void set_print_shift_along_y(const int64_t& value) { this->print_shift_along_y = value; }

		const int64_t& get_ChargerColor() const { return ChargerColor; }
		int64_t& get_mutable_ChargerColor() { return ChargerColor; }
		void set_ChargerColor(const int64_t& value) { this->ChargerColor = value; }
	};

	void from_json(const json& j, PrintShift_Name::PrintShift& x);
	void to_json(json& j, const PrintShift_Name::PrintShift& x);

	inline void from_json(const json& j, PrintShift_Name::PrintShift& x) {
		x.set_print_shift_along_x(j.at("PrintShiftAlongX").get<int64_t>());
		x.set_print_shift_along_y(j.at("PrintShiftAlongY").get<int64_t>());
		x.set_ChargerColor(j.at("ChargerColor").get<int64_t>());

	}

	inline void to_json(json& j, const PrintShift_Name::PrintShift& x) {
		j = json::object();
		j["PrintShiftAlongX"] = x.get_print_shift_along_x();
		j["PrintShiftAlongY"] = x.get_print_shift_along_y();
		j["ChargerColor"] = x.get_ChargerColor();

	}


}