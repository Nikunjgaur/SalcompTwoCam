#pragma once
#pragma once
#include<fstream>
#include<istream>
#include<iostream>
#include<string>
#include <nlohmann/json.hpp>

using json = nlohmann::json;
namespace RectanglePoint_namespace {
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

	class RectanglePoint {
	public:
		RectanglePoint() = default;
		virtual ~RectanglePoint() = default;

	private:
		int64_t point_a_x;
		int64_t point_a_y;
		int64_t point_b_x;
		int64_t point_b_y;

	public:
		const int64_t& get_point_a_x() const { return point_a_x; }
		int64_t& get_mutable_point_a_x() { return point_a_x; }
		void set_point_a_x(const int64_t& value) { this->point_a_x = value; }

		const int64_t& get_point_a_y() const { return point_a_y; }
		int64_t& get_mutable_point_a_y() { return point_a_y; }
		void set_point_a_y(const int64_t& value) { this->point_a_y = value; }

		const int64_t& get_point_b_x() const { return point_b_x; }
		int64_t& get_mutable_point_b_x() { return point_b_x; }
		void set_point_b_x(const int64_t& value) { this->point_b_x = value; }

		const int64_t& get_point_b_y() const { return point_b_y; }
		int64_t& get_mutable_point_b_y() { return point_b_y; }
		void set_point_b_y(const int64_t& value) { this->point_b_y = value; }
	};



	void from_json(const json& j, RectanglePoint_namespace::RectanglePoint& x);
	void to_json(json& j, const RectanglePoint_namespace::RectanglePoint& x);

	inline void from_json(const json& j, RectanglePoint_namespace::RectanglePoint& x) {
		x.set_point_a_x(j.at("point_a_x").get<int64_t>());
		x.set_point_a_y(j.at("point_a_y").get<int64_t>());
		x.set_point_b_x(j.at("point_b_x").get<int64_t>());
		x.set_point_b_y(j.at("point_b_y").get<int64_t>());
	}

	inline void to_json(json& j, const RectanglePoint_namespace::RectanglePoint& x) {
		j = json::object();
		j["point_a_x"] = x.get_point_a_x();
		j["point_a_y"] = x.get_point_a_y();
		j["point_b_x"] = x.get_point_b_x();
		j["point_b_y"] = x.get_point_b_y();
	}
}