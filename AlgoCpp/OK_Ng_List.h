
#pragma once
#include<fstream>
#include<istream>
#include<iostream>
#include<string>
#include <nlohmann/json.hpp>

using json = nlohmann::json;

namespace OK_Ng_List_namespace {
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

	class OkNgListElement {
	public:
		OkNgListElement() = default;
		virtual ~OkNgListElement() = default;

	private:
		bool result;
		int64_t point_a_x;
		int64_t point_a_y;
		int64_t point_b_x;
		int64_t point_b_y;

	public:
		const bool& get_result() const { return result; }
		bool& get_mutable_result() { return result; }
		void set_result(const bool& value) { this->result = value; }

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

	class OkNgList {
	public:
		OkNgList() = default;
		virtual ~OkNgList() = default;

	private:
		std::vector<OkNgListElement> ok_ng_list;
		nlohmann::json message;
		nlohmann::json final_result;

	public:
		const std::vector<OkNgListElement>& get_ok_ng_list() const { return ok_ng_list; }
		std::vector<OkNgListElement>& get_mutable_ok_ng_list() { return ok_ng_list; }
		void set_ok_ng_list(const std::vector<OkNgListElement>& value) { this->ok_ng_list = value; }

		const nlohmann::json& get_message() const { return message; }
		nlohmann::json& get_mutable_message() { return message; }
		void set_message(const nlohmann::json& value) { this->message = value; }

		const nlohmann::json& get_final_result() const { return final_result; }
		nlohmann::json& get_mutable_final_result() { return final_result; }
		void set_final_result(const nlohmann::json& value) { this->final_result = value; }
	};


	void from_json(const json& j, OK_Ng_List_namespace::OkNgListElement& x);
	void to_json(json& j, const OK_Ng_List_namespace::OkNgListElement& x);

	void from_json(const json& j, OK_Ng_List_namespace::OkNgList& x);
	void to_json(json& j, const OK_Ng_List_namespace::OkNgList& x);

	inline void from_json(const json& j, OK_Ng_List_namespace::OkNgListElement& x) {
		x.set_result(j.at("result").get<bool>());
		x.set_point_a_x(j.at("point_a_x").get<int64_t>());
		x.set_point_a_y(j.at("point_a_y").get<int64_t>());
		x.set_point_b_x(j.at("point_b_x").get<int64_t>());
		x.set_point_b_y(j.at("point_b_y").get<int64_t>());
	}

	inline void to_json(json& j, const OK_Ng_List_namespace::OkNgListElement& x) {
		j = json::object();
		j["result"] = x.get_result();
		j["point_a_x"] = x.get_point_a_x();
		j["point_a_y"] = x.get_point_a_y();
		j["point_b_x"] = x.get_point_b_x();
		j["point_b_y"] = x.get_point_b_y();
	}

	inline void from_json(const json& j, OK_Ng_List_namespace::OkNgList& x) {
		x.set_ok_ng_list(j.at("ok_ng_list").get<std::vector<OK_Ng_List_namespace::OkNgListElement>>());
		x.set_message(OK_Ng_List_namespace::get_untyped(j, "message"));
		x.set_final_result(OK_Ng_List_namespace::get_untyped(j, "final_result"));
	}

	inline void to_json(json& j, const OK_Ng_List_namespace::OkNgList& x) {
		j = json::object();
		j["ok_ng_list"] = x.get_ok_ng_list();
		j["message"] = x.get_message();
		j["final_result"] = x.get_final_result();
	}




}